    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() => SomeTask());
        }
        public void SomeTask() //this will result in 'Invalid operation exception.'
        {
            var myhandle = System.Drawing.Graphics.FromHwnd(Handle);
            myhandle.DrawLine(new Pen(Color.Red), 0, 0, 100, 100);
        }
    }
