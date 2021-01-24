    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            StartWork(1.234).Start();
        }
        public async Task StartWork(double argument)
        {
            label1.Text=$"Work Started with {argument}";
            this.Refresh();
            // Do all the work here
            await Task.Run(() => Thread.Sleep(2000));
            // 
            label1.Text="Work Finished";
            this.Refresh();
            Thread.Sleep(500);
            label1.Text=String.Format("Result = {0}", Math.PI);
            this.Refresh();
        }
    }
