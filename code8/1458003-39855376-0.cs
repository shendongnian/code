    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO.Ports;
    using System.Threading;
    
    
    namespace ForTest
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                string[] ports = SerialPort.GetPortNames();
                foreach (string port in ports)
                {
                    SerialPort sp = new SerialPort(port, 9600, Parity.None, 8, StopBits.One);
                    try
                    {
                        sp.Open();
                        try
                        {
                            sp.WriteLine("B"); // Send 1 to Arduino
                            sp.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    catch (Exception ek)
                    {
                        System.Diagnostics.Debug.WriteLine(ek.Message);
                    }
                }
                 
                
            } 
           
        }
    }
