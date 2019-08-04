using AtlassianEO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlassianBI.Utils
{
    public class Utilities
    {
        private static Utilities _instance;

        public static Utilities Instance
        {
            get
            {
                _instance = _instance ?? new Utilities();
                return _instance;
            }
        }


        public RatesEO CalculateConversion(List<RatesEO> listRates, string fromData, string toData)
        {
            RatesEO rate = null;
            rate = listRates.Where(r => r.From.ToLower() == fromData.ToLower() 
                                    &&  r.To.ToLower() == toData.ToLower()).FirstOrDefault();
            if (rate == null)
            {
                List<RatesEO> listFrom = listRates.Where(r => r.From.ToLower() == fromData.ToLower()).ToList();

                int index = 0;
                bool flag=true;
                do
                {
                    List<RatesEO> listTo = listRates.Where(r => r.From.ToLower() == listFrom[index].To.ToLower() && r.To.ToLower()== toData.ToLower()).ToList();

                    if (!listTo.Count.Equals(0))
                    {
                        rate = (from o in listFrom
                                join d in listTo
                                on o.To equals d.From
                                select new RatesEO
                                {
                                    From = o.From,
                                    To = d.To,
                                    rate = Math.Ceiling(o.rate * d.rate)
                                }
                            ).FirstOrDefault();

                        if (rate != null)
                        {
                            flag = false;
                        }
                    }
                    else
                    {
                        flag = false;
                    }
                    
                    index++;

                } while (flag);
            }

            return rate;
        }
    }
}
