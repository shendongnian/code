    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private static Process InterProc;
            public Form1()
            {
                InitializeComponent();
                InterProc = new Process();
                InitializeInterpreter();
            }
    
            private void InitializeInterpreter()
            {
                InterProc.StartInfo.FileName = @"C:\Python27\python.exe";
                InterProc.StartInfo.Arguments = @"-i"; // drops python into interactive mode after executing script if passed any
                InterProc.StartInfo.UseShellExecute = false;
                InterProc.StartInfo.RedirectStandardInput = true;
                InterProc.StartInfo.RedirectStandardOutput = true;
                InterProc.StartInfo.RedirectStandardError = true;
                InterProc.StartInfo.CreateNoWindow = true;
                InterProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                InterProc.OutputDataReceived += new DataReceivedEventHandler(InterProcOutputHandler);
                InterProc.ErrorDataReceived += new DataReceivedEventHandler(InterProcOutputHandler);
    
                bool started = InterProc.Start();
    
                InterProc.BeginOutputReadLine();
                InterProc.BeginErrorReadLine();
            }
    
            private void AppendTextInBox(TextBox box, string text)
            {
                if (InvokeRequired)
                {
                    Invoke((Action<TextBox, string>)AppendTextInBox, OutputTextBox, text);
                }
                else
                {
                    box.Text += text;
                }
            }
    
            private void InterProcOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
            {
                AppendTextInBox(OutputTextBox, outLine.Data + Environment.NewLine);
            }
    
            private void Enterbutton_Click(object sender, EventArgs e)
            {
                InterProc.StandardInput.WriteLine(CommandTextBox.Text);
            }
        }
    }
