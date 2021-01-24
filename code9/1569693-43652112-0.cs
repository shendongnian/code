    public interface IDevice
    {
        public void SendCommand1();
        
        public void SendCommand2();
    }
    public class DeviceA implements IDevice
    {
        public void SendCommand1()
        {
            // send new byte[] { 0x01, 0x02 }
        }
        
        public void SendCommand2()
        {
            // send new byte[] { 0x03, 0x04 }
        }
    }
    public class DeviceB implements IDevice
    {
        public void SendCommand1()
        {
            // send "command 1"
        }
        
        public void SendCommand2()
        {
            // send "command 2"
        }
    }
