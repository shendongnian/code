    public partial class Form1 : Form
    {
        BackgroundWorker bk;
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.bk=new BackgroundWorker();
            bk.RunWorkerCompleted+=(s, ev) =>
            {
              label1.Text=String.Format("Result={0}", ev.Result.ToString());
            };
            bk.DoWork+=(s, ev) => { ev.Result=this.StartWork((double)ev.Argument); };
            bk.RunWorkerAsync(1.234);
        }
        void SetLabel(string text)
        {
            label1.Text=text;
            this.Refresh();
        }
        delegate void LabelAction(string text);
        public double StartWork(double argument)
        {
            if (label1.InvokeRequired)
            {
                label1.Invoke(new LabelAction(SetLabel), $"Work Started with {argument}");
            }
            // Do all the work here
            Thread.Sleep(2000);
            if (label1.InvokeRequired)
            {
                label1.Invoke(new LabelAction(SetLabel), "Work Finished");
            }
            Thread.Sleep(500);
            return Math.PI;
        }
    }
