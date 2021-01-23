    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WindowsFormsApplication4
    {
    public partial class Form1 : Form
    {
        int RxRead;
        int n;
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = "COM3";
            serialPort1.BaudRate = 9600;
            serialPort1.Open();
        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            for (n = 0; n < 23; n++)
            {
                if (serialPort1.BytesToRead > 0)
                {
                    RxRead = serialPort1.ReadByte();
                    if (n == 0)
                    {
                        textBox1.AppendText(RxRead.ToString());
                    }
                    if (n == 1)
                    {
                        textBox2.AppendText(RxRead.ToString());
                    }
                    if (n == 2)
                    {
                        textBox3.AppendText(RxRead.ToString());
                    }
                    if (n == 3)
                    {
                        textBox4.AppendText(RxRead.ToString());
                    }
                    if (n == 4)
                    {
                        textBox5.AppendText(RxRead.ToString());
                    }
                    if (n == 5)
                    {
                        textBox6.AppendText(RxRead.ToString());
                    }
                    if (n == 6)
                    {
                        serialPort1.Close();
                    }
                }
            }
        }
    }
    }
