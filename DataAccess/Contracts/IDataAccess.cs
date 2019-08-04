using AtlassianEO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlassianDA.Contracts
{
    public interface IDataAccess
    {
        List<RatesEO> ListConversion();

        List<TransactionsEO> ListTransaction();
       
    }
}
