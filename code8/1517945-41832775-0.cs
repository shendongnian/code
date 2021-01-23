    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Threading;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string sScriptPath = @"C:\temp\test.js";
                File.WriteAllText(sScriptPath, @"
    //Your JavaScript goes here!
    WScript.Echo(myFunction(1, 2));
    function myFunction(p1, p2) {
        return p1 * p2; // The function returns the product of p1 and p2
    }
    ");
                var oManagedProcess = new cManagedProcess("cscript.exe", sScriptPath);
                int iExitCode = oManagedProcess.Start();
                Console.WriteLine("iExitCode = {0}\nStandardOutput: {1}\nStandardError: {2}\n", 
                    iExitCode, 
                    oManagedProcess.StandardOutput,
                    oManagedProcess.StandardError
                    );
                Console.WriteLine("Press any key...");
                Console.ReadLine();
            }
        }
        public class cManagedProcess
        {
            private Process moProcess;
            public ProcessStartInfo StartInfo;
            private StringBuilder moOutputStringBuilder;
            public string StandardOutput
            {
                get
                {
                    return moOutputStringBuilder.ToString();
                }
            }
            private StringBuilder moErrorStringBuilder;
            public string StandardError
            {
                get
                {
                    return moErrorStringBuilder.ToString();
                }
            }
            public int TimeOutMilliSeconds = 10000;
            public bool ThrowStandardErrorExceptions = true;
            public cManagedProcess(string sFileName, string sArguments)
            {
                Instantiate(sFileName, sArguments);
            }
            public cManagedProcess(string sFileName, string sFormat, params object[] sArguments)
            {
                Instantiate(sFileName, string.Format(sFormat, sArguments));
            }
            private void Instantiate(string sFileName, string sArguments)
            {
                this.StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    FileName = sFileName,
                    Arguments = sArguments
                };
            }
            private AutoResetEvent moOutputWaitHandle;
            private AutoResetEvent moErrorWaitHandle;
            /// <summary>
            /// Method to start the process and wait for it to terminate
            /// </summary>
            /// <returns>Exit Code</returns>
            public int Start()
            {
                moProcess = new Process();
                moProcess.StartInfo = this.StartInfo;
                moProcess.OutputDataReceived += cManagedProcess_OutputDataReceived;
                moProcess.ErrorDataReceived += cManagedProcess_ErrorDataReceived;
                moOutputWaitHandle = new AutoResetEvent(false);
                moOutputStringBuilder = new StringBuilder();
                moErrorWaitHandle = new AutoResetEvent(false);
                moErrorStringBuilder = new StringBuilder();
                bool bResourceIsStarted = moProcess.Start();
                moProcess.BeginOutputReadLine();
                moProcess.BeginErrorReadLine();
                if (
                    moProcess.WaitForExit(TimeOutMilliSeconds)
                    && moOutputWaitHandle.WaitOne(TimeOutMilliSeconds)
                    && moErrorWaitHandle.WaitOne(TimeOutMilliSeconds)
                    )
                {
                    if (mbStopping)
                    {
                        return 0;
                    }
                    if (moProcess.ExitCode != 0 && ThrowStandardErrorExceptions)
                    {
                        throw new Exception(this.StandardError);
                    }
                    return moProcess.ExitCode;
                }
                else
                {
                    throw new TimeoutException(string.Format("Timeout exceeded waiting for {0}", moProcess.StartInfo.FileName));
                }
            }
            private bool mbStopping = false;
            public void Stop()
            {
                mbStopping = true;
                moProcess.Close();
            }
            private void cManagedProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
            {
                DataRecieved(e, moOutputWaitHandle, moOutputStringBuilder);
            }
            private void cManagedProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
            {
                DataRecieved(e, moErrorWaitHandle, moErrorStringBuilder);
            }
            private void DataRecieved(DataReceivedEventArgs e, AutoResetEvent oAutoResetEvent, StringBuilder oStringBuilder)
            {
                if (e.Data == null)
                {
                    oAutoResetEvent.Set();
                }
                else
                {
                    oStringBuilder.AppendLine(e.Data);
                }
            }
        }
    }
