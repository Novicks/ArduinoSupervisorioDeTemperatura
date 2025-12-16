using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoArduinoIntegradoaoBanco
{
    internal class DAL
    {
        private static string strConnection = "Data Source=arduinoDados.db;version=3";
        private static SQLiteConnection conn = new SQLiteConnection(strConnection);
        private static SQLiteCommand cmd;

        public static void conectarDB()
        {
            try
            {
                conn.Open();
            } catch (Exception)
            {
                Erro.setMsg("Problema ao se conectar ao Banco de Dados...");
            }
        }
        public static void desconectarDB()
        {
                conn.Close();
        }
        public static void inserirDados(ArduinoReceptor ard)
        {
            String aux = "insert into tb_dados(Temperatura,Umidade,Data) values (@temp,@umi,@data)";
            cmd = new SQLiteCommand(aux, conn);

            cmd.Parameters.AddWithValue("@temp", ard.getTemp());
            cmd.Parameters.AddWithValue("@umi", ard.getUmi());
            cmd.Parameters.AddWithValue("@data", DateTime.Now);
            cmd.ExecuteNonQuery();
        }
    }
}
