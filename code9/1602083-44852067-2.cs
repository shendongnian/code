    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
        }
        Process p;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            p?.Dispose();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (p != null)
                p.Dispose();
            p = new Process();
            p.StartInfo.WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            p.StartInfo.FileName = "test.bat";
            p.StartInfo.Arguments = "";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.OutputDataReceived += proc_OutputDataReceived;
            p.Start();
            p.BeginOutputReadLine();
        }
        private void proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke((Action)(() =>
            {
                textBox1.AppendText(Environment.NewLine + e.Data);
            }));
            //can use either of these lines.
            (sender as Process)?.StandardInput.WriteLine();
            //p.StandardInput.WriteLine();
        }
    }
