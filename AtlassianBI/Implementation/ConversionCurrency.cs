using System;
using System.Collections.Generic;
using AtlassianBI.Contracts;
using AtlassianBI.Utils;
using AtlassianDA.Contracts;
using AtlassianEO.Entities;
using AtlassianLOG.Interface;

namespace AtlassianBI.Implementation
{
    public class ConversionCurrency: IConversionCurrency
    {
        private IDataAccess _dataAccess;
        private IFileLog _fileLog;

        public ConversionCurrency(IDataAccess dataAccess, IFileLog filelog)
        {
            _dataAccess = dataAccess;
            _fileLog = filelog;
        }

        public RatesEO Get(string fromCurrency, string toCurrency)
        {
            RatesEO Rates = null;
            List<RatesEO> listRates;
          
            try
            {

                if (!string.IsNullOrEmpty(fromCurrency) && !string.IsNullOrEmpty(toCurrency))
                {
                    listRates = _dataAccess.ListConversion();
                    if (listRates != null)
                    {
                        Rates = Utilities.Instance.CalculateConversion(listRates, fromCurrency, toCurrency);
                        if (Rates == null)
                            throw new Exception("Conversion no disponible");
                    }
                    else
                    {
                        throw new Exception("El acceso a la informacion no se encuentra disponible en estos momentos. Por favor intentelo mas tarde.");
                    }
                }
                else
                {
                    throw new Exception("Parametros obligatorios para la conversión de moneda");
                }
                return Rates;
            }
            catch (Exception ex)
            {
                _fileLog.WriteLog(string.Format("{0}. Origen de la excepcion:{1}.", ex.Message, ex.StackTrace));
                return Rates;
            }

        }

    

        public List<RatesEO> List()
        {
            List<RatesEO> listRates = null;
            try
            {
                listRates = _dataAccess.ListConversion();
                if (listRates == null)
                    throw new Exception("Acceso a la informacion no disponibles");

               return listRates;
            }
            catch (Exception ex)
            {
                _fileLog.WriteLog(string.Format("{0}. Origen de la excepcion:{1}.", ex.Message, ex.StackTrace));
                return listRates;
            }
          
        }


    }
}
