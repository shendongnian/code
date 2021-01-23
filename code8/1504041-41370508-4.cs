    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private async void button1_Click(object sender, EventArgs e)
        {
            File.Delete("Progress.txt");
            await SomeAsyncRoutine();
        }
    
        async Task SomeAsynMethod(IProgress<double> progress)
        {
            double percentCompletedSoFar = 0;
            bool completed = false;
            while (!completed)
            {
                // your code here to do something
                for (int i = 1; i <= 100; i++)
                {
                    percentCompletedSoFar = i;
                    var t = new Task(() => WriteToProgressFile(i));
                    t.Start();
                    await t;
                    if (progress != null)
                    {
                        progress.Report(percentCompletedSoFar);
                    }
                    completed = i == 100;
                }
            }
        }
    
        private void WriteToProgressFile(int i)
        {
            File.AppendAllLines("Progress.txt",
                        new[] { string.Format("Completed: {0}%", i.ToString()) });
            Thread.Sleep(100);
        }
    
        async Task SomeAsyncRoutine()
        {
            var progress = new Progress<double>();
            progress.ProgressChanged += (sender, args) =>
            {
                // Update your progress bar and do whatever else you need
                this.progressBar1.Value = (int) args;
                this.label1.Text = args.ToString();
                if (args == 100)
                {
                    MessageBox.Show("Done");
                }
            };
    
            await SomeAsynMethod(progress);
        }
    }
 
