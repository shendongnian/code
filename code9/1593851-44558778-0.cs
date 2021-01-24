    //Finally got it. This worked for me.
    
    namespace reallandtest.Entity 
    {
    
        public class DeviceCommEty
        {
            public DeviceCommEty() { }
    
            public DeviceConnection deviceConnection
            {
                get { return deviceConnection; }
                set { deviceConnection= value; }
            }
    
            public Device device
            {
                get { return device; }
                set { device= value; }
            }
    
        }
    
    }
