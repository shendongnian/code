    public partial class Form1 : Form
    {
        private Device device;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Thread deviceThread = new Thread(new ThreadStart(InitializeThread));
            deviceThread.IsBackground = true;
            deviceThread.Start();
        }
        private void InitializeThread()
        {
            device = Device.MyDevice;
            device.Init();
            /*
            while (running)
            {
               if (work != null)
               {
                  work();
                  work = null;
               }
            }
            */
        }
    }
    class Service
    {
        public event EventHandler Connected;
        public Service(string name)
        {
        }
        public void Connect()
        {
            System.Threading.Thread.Sleep(2000);
            Connected(this, new EventArgs());
        }
    }
    class Device
    {
        private Device()
        {
        }
        public static Device MyDevice
        {
            get
            {
                return Nested.instance;
            }
        }
        private class Nested
        {
            static Nested()
            {
            }
            internal static readonly Device instance = new Device();
        }
        public void Init()
        {
            Service service = new Service("service");
            service.Connected += new EventHandler(ServiceConnected);
            service.Connect();
        }
        private void ServiceConnected(object sender, EventArgs e)
        {
            //do more stuff
            Console.WriteLine("ServiceConnected");
        }
    }
