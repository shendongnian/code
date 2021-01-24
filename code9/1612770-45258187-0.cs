    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication8
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                //form constractor 
                InitializeComponent();
            }
            timer mytimer;
            private void Form1_Load(object sender, EventArgs e)
            {
                //perform event click for button automaticly 
                button1.PerformClick(); 
            }
            private void Elipse()
            {
                //the code for timer :) //yazeed coding  ,,,, write any other code
                new Thread(() => MessageBox.Show("Successful")).Start();
                Text = DateTime.Now.TimeOfDay.Seconds.ToString();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                mytimer = new timer();
                mytimer.elipse += Elipse;
                mytimer.Interval = 1000;
                mytimer.Enable = true;
                mytimer.start(this);
            }
        }
    }
    class timer
    {
        bool isstart;
        internal delegate void Del();
        internal Del elipse;
        static void UserRep() { }
        internal bool Enable { get; set; }
        internal int Interval { get; set; }
        internal timer(int val=100)
        {
            Enable = false;
            Interval = val>0?val:100;//default is 1 sec
            isstart = false;
            elipse = new Del(UserRep);
        }
        internal void start(Form Context)
        {
             new Thread(async () =>
            {
                isstart = true;
                do
                {
                    await Task.Delay(Interval);
                    new Thread(() => Context.BeginInvoke((MethodInvoker)delegate
                   {
                       elipse(); //the replacment running now (interface thrad protected)
                   })).Start();
                }
                while (isstart);
            }).Start();
        }
        internal void stop()
        {
            isstart = false;
        }
    }
