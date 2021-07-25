using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace Funcoes
{
    
    public static class FuncoesJson
    {
        private static string result = "";
        
        public static int UpdateJsonValues(string file, string jsonValues)
        {
            Logs.GerarLog($"UpdateJsonValues");

            JObject json = LoadJsonFile(file);

            if (json == null)
            {
                return 0;
            }

            JObject values = LoadJson(jsonValues);

            if (values == null)
            {
                return 0;
            }

            try
            {
                json.Merge(values);

                string text = json.ToString();

                SaveTextFile(file, text);
        }
            catch (Exception e)
            {
                result = e.Message;
                return 0;
            }

            return 1;
        }

        private static JObject LoadJson(string text)
        {
            try
            {
                Logs.GerarLog($"LoadJson");

                JObject obj = JObject.Parse(text);

                Logs.GerarLog($"LoadJson.Ok");

                return obj;
            }
            catch (Exception e)
            {
                result = e.Message;
                return null;
            }
        }

        private static JObject LoadJsonFile(string file)
        {
            try
            {
                Logs.GerarLog($"LoadJsonFile");

                using (StreamReader r = new StreamReader(file))
                {
                    Logs.GerarLog($"ReadToEnd");

                    string jsonText = r.ReadToEnd();
                    Logs.GerarLog($"LoadJsonFile.LoadJson");
                    JObject obj = LoadJson(jsonText);

                    Logs.GerarLog($"LoadJsonFile.Ok");
                    return obj;
                }
            }
            catch (Exception e)
            {
                result = e.Message;
                return null;
            }
        }

        private static void SaveTextFile(string fileName, string text)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, false))
            {
                file.WriteLine(text);
            }
        }

        

    }
}
