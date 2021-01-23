        const int MessageSize = 256;
        byte[] test = new byte[MessageSize];
        int offset = 0;
        static void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort port = (SerialPort)sender;
            try
            {
                offset += port.Read(test, offset, MessageSize - offset);
                if(offset == MessageSize)
                {
                    string data2 = "";
                    for (int i = 0; i < 60; i++)
                    {
                        data2 += test[i] + " ";
                    }
                    string writeOut = count + " - " + DateTime.Now.ToString("h:mm:ss tt") + ": " + data2;
                    Console.WriteLine(writeOut);
                    file.WriteLine(writeOut);
                    count++;
                    offset = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
