using RGiesecke.DllExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Funcoes
{
    [Guid("2A2BCDA7-CC30-4B8A-A66F-9E5C2A6B2FFD")]
    [ComVisible(true)]
    static class FuncoesExemplo
    {

        [DllExport]
        public static string TesteStr()
        {
            return "AB";
        }

        [DllExport]
        public static int TesteInt()
        {
            return 10;
        }

        [DllExport]
        public static string TesteStr2(string A, string B)
        {
            return $"{A} + {B}";
        }

    }
}
