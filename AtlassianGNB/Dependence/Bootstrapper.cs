using AtlassianBI.Contracts;
using AtlassianBI.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AtlassianBI.Dependence;
using AtlassianLOG.Interface;
using AtlassianLOG.Implementation;

namespace AtlassianGNB.Dependence
{
    public static class Bootstrapper
    {
        public static void Init()
        {
            DependencyInjector.Register<IConversionCurrency, ConversionCurrency>();
            DependencyInjector.Register<ITransactions, Transactions>();
            DependencyInjector.AddExtension<DependenceBusinessExtension>();
        }
    }
}