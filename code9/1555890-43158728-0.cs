    public class Program
    {
        static void Main(string[] args)
        {
            Global.ServiceABC.MethodA();
            Global.ServiceXYZ.MethodB();
        }
    }
    public class Global
    {
        private static ABC serviceABC;
        public static ABC ServiceABC  { get
            {
                if (serviceABC == null)
                {
                    serviceABC = new ABC();
                }
                return serviceABC;
            }
        }
        private static XYZ serviceXYZ;
        public static XYZ ServiceXYZ
        {
            get
            {
                if (serviceXYZ == null)
                {
                    serviceXYZ = new XYZ();
                }
                return serviceXYZ;
            }
        }
    }
    public class ABC
    {
        public void MethodA() { }
    }
    public class XYZ
    {
        public void MethodB() { }
    }
