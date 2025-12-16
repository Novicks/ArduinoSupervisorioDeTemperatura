using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoArduinoIntegradoaoBanco
{
    public partial class Form1 : Form
    {
        
        string[] ports = SerialPort.GetPortNames();
        ArduinoReceptor arduinoDados = new ArduinoReceptor();
        float temperaturaL;
        bool alerta = false;
        bool conectadoDB;

        // teste de monitoramento de variavel
        private bool _conectado;
        public bool Conectado
        {
            get => _conectado;
            set
            {
                if(_conectado != value)
                {
                    _conectado = value;
                    mudandoEstadoDeConexao();
                }
            }
        }

        private void mudandoEstadoDeConexao()
        {
            if (Conectado)
            {
                conectadoDB = true;
            }
            else
            {
                conectadoDB = false;
            }
        }

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;

            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
            }
            this.trackBar1.Minimum = -40;
            this.trackBar1.Maximum = 80;
            label7.Text = trackBar1.Minimum.ToString();
            label8.Text = trackBar1.Maximum.ToString();
            trackBar1.Value = trackBar1.Maximum;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Botão "Conectar-se a porta COM"
            // conecta ao arduino
            // ex :serialPort1.PortName= "COM12";

            try
            {
                serialPort1.Open();
                timer1.Start();
                Conectado = true;

                if(Conectado == true)
                {
                    button2.Enabled = true;
                    button3.Enabled = true;
                    label3.Text = "Conectado com o banco";
                    label3.ForeColor = Color.Green;
                    button4.Enabled = true;
                    comboBox1.Enabled = false;
                }
            }
            catch (Exception)
            {
                Erro.setMsg($"Não foi possivel se conectar a porta COM {Erro.getErro()} - Certifique-se de que essa porta está disponivel.");
                MessageBox.Show(Erro.getMens());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Conectado == true)
            {
                if (arduinoDados.getTemp() > 0 & arduinoDados.getUmi() > 0) 
                {
                    chart1.Series["Umidade"].Points.AddY(arduinoDados.getUmi());
                    chart1.Series["Temperatura"].Points.AddY(arduinoDados.getTemp());

                    BLL.inserirDadosDB(arduinoDados);
                    Refresh();
                }
                if ((Math.Abs(arduinoDados.getTemp() - temperaturaL)) <= (temperaturaL * (95/100)))
                {
                    label5.Text = "PERIGO";
                    label5.ForeColor = Color.Red;
                    panel1.Visible = true;
                }
                else
                {
                    label5.Text = "--------------------";
                    label5.ForeColor = Color.Transparent;
                    panel1.Visible = false;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Botão parar
            timer1.Stop();
            serialPort1.Close();
            Conectado = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Botão Recomeçar
            timer1.Start();
            serialPort1.Open();
            Conectado = true;
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if(Conectado == true)
                {
                    string dado = serialPort1.ReadLine();
                    string[] dados = dado.Split(' ');
                    // umidade depois temperatura
                    arduinoDados.setUmidade(float.Parse(dados[0]));
                    arduinoDados.setTemp(float.Parse(dados[1]));
                }
            }
            catch (Exception)
            {
                Erro.setMsg("Não foi recebido nenhum dado");
                MessageBox.Show(Erro.getMens());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // botão gera relatorio em EXCELL
            // Em processo de produção
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // botão abrir local do arquivo
            // Em processo de produção
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // botão editiar temperatura limite
            trackBar1.Enabled = true;
            button6.Enabled = false;
            button7.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // botão salvar temperatura limite
            trackBar1.Enabled = false;
            button6.Enabled = true;
            button7.Visible = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            temperaturaL = trackBar1.Value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BLL.conecta();
        }
    }
}
