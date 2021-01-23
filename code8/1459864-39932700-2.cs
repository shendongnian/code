    // Platforms
    public class StandardPlatform : Platform { }
    public class DeluxPlatform : Platform { }
    public class JumboPlatform : Platform { } 
    // Capture device(s)
    public class CD1 : CaptureDevice
    {
        public CD1()
        {
            Platform = new StandardPlatform();
        }
    }
    
    // Sensor device(s)
    public class SD1 : SensorDevice
    {
        public SD1()
        {
            Platforms = new List<Platform>
            {
                new StandardPlatform(),
                new DeluxPlatform()
            };
        }
    }
    public class SD2 : SensorDevice
    {
        public SD2()
        {
            Platforms = new List<Platform> {new JumboPlatform()};
        }
    }
    
    // Somewhere in the code...
    var cd1 = new CD1();
    var sd1 = new SD1();
    Console.WriteLine(cd1.IsCompatibleWith(sd1)); // True
    Console.WriteLine(sd1.IsCompatibleWith(cd1)); // True
    var sd2 = new SD2();
    Console.WriteLine(sd2.IsCompatibleWith(cd1)); // False
    Console.WriteLine(cd1.IsCompatibleWith(sd2)); // False
