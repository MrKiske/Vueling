using System;
using System.IO;
using AtlassianLOG.Interface;

namespace AtlassianLOG.Implementation
{
    public class FileLog : IFileLog
    {
        private const string extension = "log";
        private string name = System.Configuration.ConfigurationManager.AppSettings["fileName"].ToString();
       
        public string CreateLog()
        {
           string fileName;
           string fullPath;
            try
            {
                fileName = string.Format("{0}{1}{2}{3}.{4}", name, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, extension);
                fullPath = Path.Combine(Path.GetTempPath(), fileName);
                if (!File.Exists(fullPath))
                    File.Create(fullPath);

                return fullPath;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        
        public void WriteLog(string message)
        {
            using (StreamWriter file = new StreamWriter(CreateLog(),true))
            {
                file.Write(string.Format("Ha ocurrido una excepcion No controlada siendo las {0}. Detalles del error:", DateTime.Now.ToLongTimeString()));
                file.WriteLine(string.Format("{0}\n\n",message));
                file.Close();
            }
        }
    }
}
