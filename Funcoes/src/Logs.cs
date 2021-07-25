using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcoes
{
    public static class Logs
    {
        public static string GerarLog(string log)
        {
            try
            {
                //string pasta = Directory.GetCurrentDirectory() + "\\Logs\\";

                string pasta = $"{Path.GetTempPath()}\\FuncoesDll\\";

                //string pasta = "c:\\FuncoesDll\\";
                if (!Directory.Exists(pasta))
                {
                    Directory.CreateDirectory(pasta);
                }
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(
                    pasta + "" + DateTime.Now.ToString("yyyy-MM-dd") + "_Funcoes.LOG",
                    true))
                {
                    file.WriteLine(DateTime.Now.ToString() + " - " + log);
                    //file.WriteLine("");
                }

                return pasta;
            }
            catch {
                return "";
            }
        }
    }
}
