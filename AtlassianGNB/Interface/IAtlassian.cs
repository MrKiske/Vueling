using AtlassianEO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AtlassianGNB.Interface
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAtlassian
    {

        [OperationContract]
        string GetListConversionCurrency();

        [OperationContract]
        string GetConversionCurrency(string fromCurrency, string toCurrency);

        [OperationContract]
        string GetListTransactions();

        [OperationContract]
        string GetTransactionsBySku(string sku);
    }
   
}
