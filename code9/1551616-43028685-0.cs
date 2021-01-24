    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;
    using System.Threading.Tasks;
    using System.Timers;
    
    namespace AveryMonitor
    {
        public partial class Service1 : ServiceBase
        {
            public Service1()
            {
                InitializeComponent();
            }
            private  System.Timers.Timer timer1;
            
            private static int check;
    
            protected override void  OnStart(string[] args)
            {
                this.timer1 = new System.Timers.Timer(15000);
                
                this.timer1.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                this.timer1.Enabled = true;
                this.timer1.Start();
                
            }
            private static void OnTimedEvent(object source, ElapsedEventArgs e)
            {
                Process[] pname = Process.GetProcessesByName("Notepad");
                if (pname.Length == 0)
                {
                    check = 0;
                }
                //MessageBox.Show("nothing");
                else
                {
                    if (check == 1)
                    {
                        
                        foreach (var process in Process.GetProcessesByName("Notepad"))
                        {
                            process.Kill();
                        }
                        check = 0;
                    }
                    else
                    {
                        check = 1;
                    }
                }
            }
                
            protected override void OnStop()
            {
                timer1.Stop();
                
                timer1.Enabled = false;
                
            }
        }
    }
