using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoArduinoIntegradoaoBanco
{
    public class BLL
    {
        public static bool conecta()
        {
            DAL.conectarDB();
            return true;
        }
        public static void desconecta()
        {
            DAL.desconectarDB();
        }
        public static void inserirDadosDB(ArduinoReceptor ard)
        {
            DAL.inserirDados(ard);
        }
    }
}
