using AtlassianDA.Contracts;
using AtlassianEO.Entities;
using Newtonsoft.Json;
using ServiceStack.Redis;
using StackExchange.Redis;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace AtlassianDA.Implementation
{
    public class DataAccess : IDataAccess
    {
        public List<RatesEO> ListConversion()
        {
            List<RatesEO> listRates = null;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://quiet-stone-2094.herokuapp.com/rates.json");
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    listRates = JsonConvert.DeserializeObject<List<RatesEO>>(json);
                }
            }



            return listRates;
        }

        public List<TransactionsEO> ListTransaction()
        {
            List<TransactionsEO> listTransactions = null;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://quiet-stone-2094.herokuapp.com/transactions.json");
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    listTransactions = JsonConvert.DeserializeObject<List<TransactionsEO>>(json);
                }
            }

            return listTransactions;
        }
    }
}
