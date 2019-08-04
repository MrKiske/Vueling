using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlassianLOG.Interface
{
    public interface IFileLog
    {
        void WriteLog(string message);

        string  CreateLog();
    }
}
