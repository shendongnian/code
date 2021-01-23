    namespace Test
    {   class Program
        {
    		const int bufSize = 2048;
            static void Main(string[] args)
            {
    
                Byte[] buf = new Byte[bufSize]; 
                SerialPort sp = new SerialPort("COM1", 115200);
                sp.DataReceived += port_OnReceiveData; // Add DataReceived Event Handler
    
                sp.Open();
    
                // Wait for data or user input to continue.
                Console.ReadLine();
    
    
                sp.Close();
            }
    
            private static void port_OnReceiveData(object sender,  SerialDataReceivedEventArgs e)
            {
    			SerialPort port = (SerialPort) sender;
    			switch(e.EventType)
    			{
    				case SerialData.Chars:
    				{
    				    Byte[] buf = new Byte[bufSize];
    					port.Read(buf, 0, bufSize)
    					Console.WriteLine("Recieved data! " + buf.ToString());
    					break;
    				}
    				case SerialData.Eof:
    				{
    					// means receiving ended
    					break;
    				}
    			}
            }
        }
    }
