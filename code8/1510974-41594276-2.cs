    public partial class Form1 : Form
        {
            Form frm1 = new Form();
            int i;
            private System.Threading.Timer t;
            //If the problem is garbage collecting then the line above is very important.
            public Form1()
            {
                InitializeComponent();
                var autoEvent = new AutoResetEvent(false);
                var stateTimer = new System.Threading.Timer(CallToChildThread,
                                       autoEvent, 1000, 250);
            }
        private void CallToChildThread(object state)
        {
            i++;
            //Updating value here, update in other timer (this is to avoid crossthreadEx)   
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            frm1.ShowDialog();
            //Label keeps updating!
        }
    
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = i.ToString();
        }
    }
