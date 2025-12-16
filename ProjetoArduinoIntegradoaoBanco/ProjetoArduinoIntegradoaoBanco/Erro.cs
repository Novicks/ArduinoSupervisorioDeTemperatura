using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoArduinoIntegradoaoBanco
{
    class Erro
    {
        private static bool erro;
        private static String mens;

        public static void setErro(bool _erro) {  erro = _erro; }
        public static void setMsg(String _msg) { erro = true; mens = _msg; }
        public static bool getErro() { return erro; }
        public static String getMens() { return mens; }
    }
}
