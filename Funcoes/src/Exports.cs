using RGiesecke.DllExport;
using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Funcoes.src
{
    [Guid("5CF2FC1E-E070-4EBD-BF29-D4C07EB56A42")]
    [ComVisible(true)]
    public static class Exports
    {

        [DllExport]
        public static string UpdateJson(string file, string jsonValues)
        {
            string result = "";

            Logs.GerarLog($"file: {file} | jsonValues: {jsonValues}");

            foreach (var resource in Assembly.GetExecutingAssembly().GetManifestResourceNames())
                Logs.GerarLog("Resource: " + resource);

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            Logs.GerarLog($"CurrentDomain_AssemblyResolve");

            FuncoesJson.UpdateJsonValues(file, jsonValues);

            Logs.GerarLog($"result: {(result == String.Empty ? "Sucesso" : result)}");
            return result;
        }

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Funcoes.embedded.Newtonsoft.Json.dll"))
            {
                var assemblyData = new Byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return Assembly.Load(assemblyData);
            }
        }
    }
}
