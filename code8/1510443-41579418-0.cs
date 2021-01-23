    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Threading;
    namespace CMD_testing
    {
        public partial class Form1 : Form
        {
        public Form1()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Process process;
            process = new Process();
            process.StartInfo.FileName = @"C:\\Project\Test\Other Data.bat";
            process.StartInfo.UseShellExecute = false;
              process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            process.StartInfo.RedirectStandardInput = true;
            process.Start();
            process.BeginOutputReadLine();
            process.Close();
        }
        private void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (outLine.Data != null)
            {
                BeginInvoke(new MethodInvoker(() => { textBox1.AppendText(outLine.Data + Environment.NewLine); }));
            }
        }
      }
   }
