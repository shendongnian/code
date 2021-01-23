    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.IO.Ports;
    using System.Threading;
    
    namespace na_posla
    {
        public partial class Form1 : Form
        {
            Thread readThread = null;
            bool threadCanRun = false;
    
            public Form1()
            {
                InitializeComponent();
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
                getAvailablePorts();
            }
    
            void getAvailablePorts()
            {
                String[] ports = SerialPort.GetPortNames();
                comboBox1.Items.AddRange(ports);
            }
    
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                    if (comboBox1.Text == "" || comboBox2.Text == "")
                    {
                        MessageBox.Show("Please select port settings");
                    }
                    else
                    {
                        serialPort1.PortName = comboBox1.Text;
                        serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text);
                        serialPort1.Open();
                        progressBar1.Value = 100;
                        button1.Enabled = false;
                        button2.Enabled = true;
                        button3.Enabled = true;
                    }
                }
    
                catch (UnauthorizedAccessException)
                {
                    textBox1.Text = "Unauthorized Access";
                }
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                serialPort1.Close();
                progressBar1.Value = 0;
                textBox1.Text = "";
    
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
            }
            private void button3_Click(object sender, EventArgs e)
            {
                if (readThread == null)
                    readThread = new Thread(ReadDataLooped);
                if (readThread.IsAlive)
                {
                    threadCanRun = false;
                    Thread.Sleep(50);
                    readThread.Abort();
                    readThread.Join();
                }
                threadCanRun = true;
                readThread.Start();
            }
            private void SetTextBoxText(TextBox txtBox, string value)
            {
                if (txtBox.InvokeRequired)
                {
                    txtBox.Invoke((MethodInvoker)delegate { SetTextBoxText(txtBox, value); });
                    return;
                }
                txtBox.Text = value;
            }
            private void ReadDataLooped(object obj)
            {
                try
                {
                    while (threadCanRun)
                        ReadAndSetData();
                }
                catch (ThreadAbortException)
                {
                    Thread.ResetAbort();
                }
            }
            private double ReadValueFromSerialPort()
            {
                string stringVal = serialPort1.ReadLine();
                if (stringVal.Contains("."))
                    stringVal = stringVal.Replace(".", ",");
                double doubleval = System.Convert.ToDouble(stringVal);
                double y = (doubleval / 5) * 40;
                return y;
            }
            private void ReadAndSetData()
            {
                this.SetTextBoxText(textBox1, this.ReadValueFromSerialPort().ToString());
            }
    
        }
    }
