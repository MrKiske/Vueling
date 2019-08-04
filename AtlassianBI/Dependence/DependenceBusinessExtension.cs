using AtlassianDA.Contracts;
using AtlassianDA.Implementation;
using AtlassianLOG.Implementation;
using AtlassianLOG.Interface;
using Unity;
using Unity.Extension;

namespace AtlassianBI.Dependence
{
    public class DependenceBusinessExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IFileLog, FileLog>();
            Container.RegisterType<IDataAccess, DataAccess>();
        }
    }  
}  
