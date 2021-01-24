    namespace TestSensor
    {
    
        public interface Iserial
        {      
            bool isOpen(int p);
            //bool open(int serialInstance, string comPortNo, int baud);
            //bool close(int p);
        }
        public class port : Iserial
        {
            public System.IO.Ports.SerialPort serialPort1 = new SerialPort();
            public System.IO.Ports.SerialPort serialPort2 = new SerialPort();
            public bool isOpen(int port)
            {
                if (port == 1)
                {
                    if (serialPort1.IsOpen) return true;
                    else return false;
                }
                else if (port == 2)
                {
                    if (serialPort2.IsOpen) return true;
                    else return false;
                }
                else return false;
            }
        }
    }
