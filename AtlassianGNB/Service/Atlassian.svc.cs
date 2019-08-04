using AtlassianEO.Entities;
using AtlassianGNB.Dependence;
using AtlassianGNB.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AtlassianGNB.Service
{
    public class Atlassian : IAtlassian
    {
        public string GetConversionCurrency(string fromCurrency, string toCurrency)
        {
            try
            {
                Bootstrapper.Init();
                Initiator initiator = DependencyInjector.Retrieve<Initiator>();
                return initiator.GetCurrency(fromCurrency, toCurrency);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        public string GetListConversionCurrency()
        {
            List<RatesEO> listRates = null;
            string errors = string.Empty;
            try
            {
                Bootstrapper.Init();
                Initiator initiator = DependencyInjector.Retrieve<Initiator>();
                listRates = initiator.GetListCurrency();
                return JsonConvert.SerializeObject(listRates);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string GetListTransactions()
        {
            List<TransactionsEO> listTransaction = null;
            try
            {
                Bootstrapper.Init();
                Initiator initiator = DependencyInjector.Retrieve<Initiator>();
                listTransaction= initiator.GetListTransactions();
                return JsonConvert.SerializeObject(listTransaction);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string GetTransactionsBySku(string sku)
        {
            try
            {
                Bootstrapper.Init();
                Initiator initiator = DependencyInjector.Retrieve<Initiator>();
                return  initiator.GetTransactionBySku(sku);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
