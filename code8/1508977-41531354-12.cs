        namespace WebService
    {
        partial class MellatBank : ServiceBase
        {
            System.Timers.Timer personalTimer = null;
    
    
            public MellatBank()
            {
                personalTimer = new System.Timers.Timer(1000);
    
                this.ServiceName = "MellatBankService";
            }
            protected override void OnStart(string[] args)
            {
                personalTimer.Elapsed += OnElapsedTimeMellat;
                personalTimer.AutoReset = true; //Add this line to keep continuos activation
                personalTimer.Enabled = true;
                //var timer = new System.Timers.Timer(5000); // fire every 30 second
                //personalTimer.Elapsed += OnElapsedTimeMellat;
                //personalTimer.Enabled = true;
            }
            private void OnElapsedTimeMellat(object source, ElapsedEventArgs e)
            {
                try
                {
                    if (!Directory.Exists(@"D:\Temp"))
                     Directory.CreateDirectory(@"D:\Temp\");
                    if (!File.Exists(@"D:\Temp\MellatBank.txt"))
                    {
    
                        var f = File.CreateText(@"D:\Temp\MellatBank.txt");
                        f.Write(@"D:\Temp\MellatBank.txt", "Mellat Bank writer\n");
                        f.Close();
                    }
                    else
                    {
                        var f = File.AppendText(@"D:\Temp\MellatBank.txt");
                        f.Write("Mellat Bank writer\n");
                        f.Close();
                    }
                }
                catch (System.Exception ex)
                {
                    Console.Error.WriteLine("IO EXCEPTION: {0}", ex.ToString());
                }
            }
            public void Start()
            {
                OnStart(new string[0]);
            }
            protected override void OnStop()
            {
                Console.Out.WriteLine("ended!");
                // TODO: Add code here to perform any tear-down necessary to stop your service.
            }
    
        }
    }
    
    
    namespace WebService
    {
        partial class AnsarBank : ServiceBase
        {
    
            System.Timers.Timer personalTimer = null;
    
            public AnsarBank()
            {
                personalTimer = new System.Timers.Timer(1000);
                this.ServiceName = "AnsarBankService";
            }
    
            protected override void OnStart(string[] args)
            {
    
    
                personalTimer.Elapsed += OnElapsedTimeAnsar;
                personalTimer.AutoReset = true; //Add this line to keep continuos activation
                personalTimer.Enabled = true;
                //var timer = new System.Timers.Timer(5000); // fire every 30 second
                //personalTimer.Elapsed += OnElapsedTimeAnsar;
                //personalTimer.Enabled = true;
            }
            private void OnElapsedTimeAnsar(object source, ElapsedEventArgs e)
            {
                try
                {
    
                    if (!Directory.Exists(@"D:\Temp"))
                        Directory.CreateDirectory(@"D:\Temp\");
                    if (!File.Exists(@"D:\Temp\Ansar.txt"))
                    {
    
                        var f = File.CreateText(@"D:\Temp\Ansar.txt");
                        f.Write(@"D:\Temp\Ansar.txt", "Ansar Bank writer\n");
                        f.Close();
                    }
                    else
                    {
                        var f = File.AppendText(@"D:\Temp\Ansar.txt");
                        f.Write("Ansar Bank Writer\n");
                        f.Close();
                    }
                }
                catch (System.Exception ex)
                {
                    Console.Error.WriteLine("IO EXCEPTION: {0}", ex.ToString());
                }
            }
            public void Start()
            {
                OnStart(new string[0]);
            }
            protected override void OnStop()
            {
                Console.Out.WriteLine("ended!");
            }
        }
    }
