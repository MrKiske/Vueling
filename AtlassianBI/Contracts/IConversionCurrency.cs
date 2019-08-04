using AtlassianEO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlassianBI.Contracts
{
    public interface IConversionCurrency
    {
        RatesEO Get(string fromCurrency, string toCurrency);
        List<RatesEO> List();

    }
}
