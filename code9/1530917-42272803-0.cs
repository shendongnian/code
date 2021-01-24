    public class MeService : ServiceBase
    {
        // for the ability to redirect stream
        [DllImport("Kernel32.dll", SetLastError = true) ]
        public static extern int SetStdHandle(int device, IntPtr handle); 
        // entry point
        public static void Main(string[] args)
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new MeService()
            };
            ServiceBase.Run(ServicesToRun);
        }
        PerformanceObject pObject; // object to retrieve and return performance status
        IContainer components;
        FileStream fStream;
        public MeService()
            : base()
        {
            components = new Container(); // initialize components holder
            ServiceName = "MeService"; // set your service name
        }
        // Here check for custom commands on your service
        protected override void OnCustomCommand(int command)
        {
            if(command == 1)
            {
                // redirect stream
                fStream = new FileStream("<path_to_your_out_file>", <FileMode.Here>, <FileAccess.Here>);
                IntPtr streamHandle = fStream.Handle;
                SetStdHandle(-11, handle); // DWORD -11  == STD OUT
            }
            else if(command == 1337 && pObject != null) // example command
            {
                // write string.Format("CPU Value: {0}, ram value: {1}", cpu, ram);
                // into your service's std out
                Console.WriteLine(pObject.GetPerformance()); 
            }
            base.OnCustomCommand(command);
        }
        // whenever service starts create a fresh performance counter object
        protected override void OnStart(string[] args) // will be called when service starts
        {
            pObject = new PerformanceObject();
        }
        // called whenever service is stopped
        protected override void OnStop()
        {
            // remove performance counter object 
            pObject.Dispose();
            pObject = null;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                if (pObject != null)
                {
                    pObject.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
