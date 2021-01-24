    public partial class Form1 : Form
    {
        private Thread myUIthred;
        public Form1()
        {
            myUIthred = Thread.CurrentThread;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() => SomeTask());
        }
        public void SomeTask() // Works Great.
        {
            if (Thread.CurrentThread != myUIthred) //Tell the UI thread to invoke me if its not him who is running me.
            {
                BeginInvoke(new Action(SomeTask));
                return;
            }
            var myhandle = System.Drawing.Graphics.FromHwnd(Handle);
            myhandle.DrawLine(new Pen(Color.Red), 0, 0, 100, 100);
        }
    }
