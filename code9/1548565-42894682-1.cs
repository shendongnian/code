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
            var bk=new BackgroundWorker();
            // This gets run when work is complete
            bk.RunWorkerCompleted+=(s, ev) =>
            {
              label1.Text=String.Format("Result={0}", ev.Result.ToString());
            };
            // This gets run to start the work
            bk.DoWork+=(s, ev) => { ev.Result=this.StartWork((double)ev.Argument); };
            bk.RunWorkerAsync(1.234);
        }
        // Form method for setting the label and refreshing the screen (needed)
        void SetLabel(string text)
        {
            label1.Text=text;
            this.Refresh();
        }
        // A delegate declaration for the above method (needed)
        delegate void LabelAction(string text);
        // This is your start work procedure. It is static because it should 
        // only interact with the form via `Control.Invoke()`.
        public static double StartWork(double argument)
        {
            // If in different thread use the `LabelAction` delegate to set the label
            if (label1.InvokeRequired)
            {
                label1.Invoke(new LabelAction(SetLabel), $"Work Started with {argument}");
            }
            // Do all the work here
            Thread.Sleep(2000);
            // We're done now
            // If in different thread use the `LabelAction` delegate to set the label
            if (label1.InvokeRequired)
            {
                label1.Invoke(new LabelAction(SetLabel), "Work Finished");
            }
            Thread.Sleep(500);
            return Math.PI;
        }
    }
