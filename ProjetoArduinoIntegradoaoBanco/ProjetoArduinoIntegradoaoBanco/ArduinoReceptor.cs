using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoArduinoIntegradoaoBanco
{
    public class ArduinoReceptor
    {
        private float yTemperatura;
        private float yUmidade;

        public void setTemp (float temp)
        {
            yTemperatura = temp;
        }
        public void setUmidade (float umi)
        {
            yUmidade = umi;
        }

        public float getTemp()
        {
            return yTemperatura;
        }
        public float getUmi()
        {
            return yUmidade;
        }
    }
}
