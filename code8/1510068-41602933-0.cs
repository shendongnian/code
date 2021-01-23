    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO.Ports;
    namespace WindowsFormsApplication22
    {
        public partial class Form1 : Form
        {
            SerialPort serialPort;
            private Action startReading;
            int bufferLength = 4096;
            string data;
            public Form1()
            {
                InitializeComponent();
            }
            public bool Open()
            {
                serialPort = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                bool result = false;
                try
                {
                    this.serialPort.Open();
                    result = true;
                    startReading = StartAsyncSerialReading;
                    startReading();
                }
                catch (Exception)
                {
                    this.Close();
                    result = false;
                }
                return result;
            }
            private void StartAsyncSerialReading()
            {
                byte[] buffer = new byte[bufferLength];
                serialPort.BaseStream.BeginRead(buffer, 0, bufferLength, delegate (IAsyncResult ar)
                {
                    try
                    {
                        if (serialPort.IsOpen)
                        {
                            int actualLength = serialPort.BaseStream.EndRead(ar);
                            byte[] received = new byte[actualLength];
                            Buffer.BlockCopy(buffer, 0, received, 0, actualLength);
                            data += Encoding.ASCII.GetString(received, 0, actualLength);
                            while (data.Contains("\n"))
                            {
                                string message = data.Substring(0, data.IndexOf("\n"));
                                Console.WriteLine(message);
                                //remove message from buffer
                                data = data.Substring(data.IndexOf("\n") + 1);
                            }
                        }
                    }
                    catch (IOException exc)
                    {
                        //## Heading ##
                    }
                    if (serialPort.IsOpen)
                        startReading();
                }, null);
            }
            public void ClosePort()
            {
                this.serialPort.Close();
                this.serialPort.Dispose();
            }
            private void button2_Click(object sender, EventArgs e)
            {
                ClosePort();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                Open();
                StartAsyncSerialReading();
            }
        }
    }
