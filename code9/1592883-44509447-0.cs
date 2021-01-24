    class Program
    {
        static void Main(string[] args)
        {
            using (SerialPort sp = new SerialPort("COM2", 19200, Parity.None, 8, StopBits.One))
            {
                //sp.DiscardNull = true;
                sp.Handshake = Handshake.XOnXOff;
                sp.ReadBufferSize = 16384;
                sp.Open();
                sp.DataReceived += sp_DataReceived;
                AppDomain.CurrentDomain.ProcessExit += new EventHandler((x, y) =>
                {
                    sp.Close();
                });
                Console.ReadKey();
            }
        }
        static string myString = string.Empty;
        static void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (sender as SerialPort);
            if (sp.BytesToRead > 0)
            {
                myString += sp.ReadExisting().Trim();
                if (myString.Last() == '\0')
                {
                    myString = myString.Trim('\0').Trim();
                    if (!string.IsNullOrWhiteSpace(myString))
                    {
                        Console.WriteLine(myString);
                    }
                    sp.DiscardInBuffer();
                    myString = string.Empty;
                }
            }
        }
    }
