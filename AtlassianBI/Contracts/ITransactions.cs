using AtlassianEO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlassianBI.Contracts
{
    public interface ITransactions
    {
        List<TransactionsEO> List();

        TransactionsEO GetBySku(string sku);
        
    }
}
