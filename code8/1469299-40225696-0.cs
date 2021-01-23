      public partial class Form1 : Form
    {
        Process[] processList1;
        public Form1()
        {
            InitializeComponent();
            processList1 = Process.GetProcesses();
        }
       //set timer1.Interval to 5000
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Process item in Process.GetProcesses())
            {
                if (!processList1.Contains(item))
                {
                    //This is a new Process
                }
            }
            processList1 = Process.GetProcesses();
        }
    }
