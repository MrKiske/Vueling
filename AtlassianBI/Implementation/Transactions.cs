using AtlassianBI.Contracts;
using AtlassianBI.Utils;
using AtlassianDA.Contracts;
using AtlassianEO.Entities;
using AtlassianLOG.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlassianBI.Implementation
{
    public class Transactions : ITransactions
    {
        private IDataAccess _dataAccess;
        private IFileLog _fileLog;
        private IConversionCurrency _conversionCurrency;
        

        public Transactions(IDataAccess dataAccess, IFileLog fileLog, IConversionCurrency conversionCurrency)
        {
            _dataAccess = dataAccess;
            _fileLog = fileLog;
            _conversionCurrency = conversionCurrency;
        }
        public TransactionsEO GetBySku(string sku)
        {
            TransactionsEO transaction = null;
            List<TransactionsEO> listTransactions = null;
            string currency = System.Configuration.ConfigurationManager.AppSettings["Currency"].ToUpper();
            try
            {
                listTransactions = _dataAccess.ListTransaction();
                if (listTransactions != null)
                {
                    if (listTransactions.Any(t => t.Sku.ToUpper() == sku.ToUpper()))
                    {
                        decimal totalAmount = 0;
                        RatesEO objRate = null;
                        List<RatesEO> listRate = _conversionCurrency.List();
                        if (listRate== null)
                            throw new Exception("Informacion de conversion de moneda no disponible intente mas tarde.");

                        foreach (TransactionsEO itemTransaction in listTransactions.Where(t => t.Sku.ToUpper() == sku.ToUpper()))
                        {
                            if (itemTransaction.Currency.ToUpper() != currency)
                            {
                                 objRate = Utilities.Instance.CalculateConversion(listRate, itemTransaction.Currency, currency);
                                if (objRate != null)
                                {
                                    totalAmount = totalAmount + (objRate.rate * itemTransaction.Amount);
                                }
                                else
                                {
                                    throw new Exception("Conversion no disponible");
                                }
                            }
                            else
                            {
                                totalAmount = totalAmount + itemTransaction.Amount;
                            }
                        }

                        transaction = new TransactionsEO()
                        {
                            Sku = sku.ToUpper(),
                            Currency = currency,
                            Amount = Math.Ceiling(totalAmount)
                        };

                        return transaction;
                    }
                    else
                    {
                        throw new Exception(string.Format("No existen productos asociados al proucto {0}", sku));
                    }
                }
                else
                {
                    throw new Exception("El acceso a la informacion no se encuentra disponible en estos momentos. Por favor intentelo mas tarde.");
                }
            }
            catch (Exception ex)
            {
                _fileLog.WriteLog(string.Format("{0}. Origen de la excepcion:{1}.", ex.Message, ex.StackTrace));
                return transaction;
            }
            
        }

        public List<TransactionsEO> List()
        {
            List<TransactionsEO> listTransactions = null; 
            try
            {
                listTransactions= _dataAccess.ListTransaction();
                if (listTransactions == null)
                    throw new Exception("El acceso a la informacion no se encuentra disponible en estos momentos. Por favor intentelo mas tarde.");

                return listTransactions;
            }
            catch (Exception ex)
            {
                _fileLog.WriteLog(string.Format("{0}. Origen de la excepcion:{1}.", ex.Message, ex.StackTrace));
                return listTransactions;
            }
            
        }
    }
}
