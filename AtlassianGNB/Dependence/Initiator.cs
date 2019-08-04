using AtlassianBI.Contracts;
using AtlassianEO.Entities;
using AtlassianLOG.Interface;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AtlassianGNB.Dependence
{
    public class Initiator
    {
        IConversionCurrency _currency;
        ITransactions _transaction;
        public Initiator(IConversionCurrency currency, ITransactions transactions)
        {
            _currency = currency;
            _transaction = transactions;
        }

        public string GetCurrency(string fromData, string toData)
        {
            RatesEO objRate;
            objRate = _currency.Get(fromData, toData);
            if (objRate != null)
            { 
                return JsonConvert.SerializeObject(objRate);
            }
            else
            {
                return "Ocurrió un error durante la ejecución del servicio. Para mas información remitase al archivo de errores."; 
            }
        }

        public List<RatesEO> GetListCurrency()
        {
            List<RatesEO> listRate = null;
            listRate= _currency.List();
            if (listRate != null)
            {
                return listRate;
            }
            else
            {
                listRate = new List<RatesEO>()
                    {
                        new RatesEO()
                        { From="Ocurrió un error durante la ejecución del servicio. Para mas información remitase al archivo de errores.",
                          rate = 0,
                          To =""
                        }
                    };

                return listRate;
            }

        }

        public List<TransactionsEO> GetListTransactions()
        {
            List<TransactionsEO> listTransaction = null;
            listTransaction = _transaction.List();
            if (listTransaction != null)
            {
                return listTransaction;
            }
            else
            {
                  listTransaction = new List<TransactionsEO>()
                    { new TransactionsEO(){ Sku="Ocurrió un error durante la ejecución del servicio. Para mas información remitase al archivo de errores.", Currency="",  Amount= 0  } };
                return listTransaction;
            }
            
        }

        public string GetTransactionBySku(string sku)
        {
            TransactionsEO objTransactions;
            objTransactions = _transaction.GetBySku(sku);
            if (objTransactions != null)
            {
                return JsonConvert.SerializeObject(objTransactions);
            }
            else
            {
                return "Ocurrió un error durante la ejecución del servicio. Para mas información remitase al archivo de errores.";
            }

        }
    }
}