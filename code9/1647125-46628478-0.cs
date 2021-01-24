    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Forms;
    using System.IO;
    
    namespace SendInput
    {
        public partial class Form1: Form
        {
            private SynchronizationContext _syncContext;
            public Form1()
            {
                InitializeComponent();
            }
            private async void btnCommand_Click(object sender, EventArgs e)
            {
                CheckForIllegalCrossThreadCalls = false;
    
                await StartProcessAsync();
            }
            private Task StartProcessAsync()
            {
                return Task.Run(()=>
                {
                    try
                    {
                        //Create Process Start information
                        ProcessStartInfo processStartInfo =
                            new ProcessStartInfo(@"C:\Users\devPC\Desktop\Server\run.bat");
                        processStartInfo.ErrorDialog = false;
                        processStartInfo.UseShellExecute = false;
                        processStartInfo.RedirectStandardError = true;
                        processStartInfo.RedirectStandardInput = true;
                        processStartInfo.RedirectStandardOutput = true;
                        //Execute the process
                        Process process = new Process();
                        process.StartInfo = processStartInfo;
                        process.OutputDataReceived += (sender, args) => UpdateText(args.Data);
                        process.ErrorDataReceived += (sender, args) => UpdateErrorText(args.Data);
                        process.Start();
                        process.BeginOutputReadLine();
                        process.BeginErrorReadLine();
                        process.WaitForExit(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }
            private void UpdateText(string outputText)
            {
                _syncContext.Post(x => rtbConsole.AppendText("Output \n==============\n"), null);                
                _syncContext.Post(x => rtbConsole.AppendText(outputText), null);
            }
            private void UpdateErrorText(string outputErrorText)
            {
                _syncContext.Post(x => rtbConsole.AppendText("\nError\n==============\n"), null);
                _syncContext.Post(x => rtbConsole.AppendText(outputErrorText), null);
            }
        }
    }
