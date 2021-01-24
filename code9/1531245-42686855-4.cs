    using System;
    namespace PSExec_42280413
    {
        class Program
        {
            static void Main(string[] args)
            {
                DoIt();
    
            }
    
            private static void DoIt()
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.ErrorDataReceived += Proc_ErrorDataReceived;
                proc.OutputDataReceived += Proc_OutputDataReceived;
                proc.Exited += Proc_Exited;
    
                proc.StartInfo.FileName = @"c:\windows\syswow64\psexec_64.exe";
                proc.StartInfo.Arguments = @"-i -u usr -p pwd \\server -c M:\StackOverflowQuestionsAndAnswers\PSExec_42280413\PSExec_42280413\TheBatFile.bat";
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.RedirectStandardInput = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.UseShellExecute = false;
                proc.EnableRaisingEvents = true;
                proc.Start();
                proc.BeginErrorReadLine();
                proc.BeginOutputReadLine();
    
                //if the process runs too quickly, the event don't have time to raise and the application exits.
                //this here takes care of slooowwwwwiiinnnnnggggg things down
                //there are more elegant ways to wait and it does not have to be this long
                Int64 bigone = 200000000;
                while (bigone > 0)
                {
                    bigone--;
                }
            }
    
            private static void Proc_Exited(object sender, EventArgs e)
            {
                //string out = ((System.Diagnostics.Process)sender).StandardError.ReadToEnd();//not while BeginErrorReadLine() is set.
                Console.WriteLine("done");
                System.Diagnostics.Debugger.Break();
            }
    
            private static void Proc_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
            {
                Console.Write("1");
                //System.Diagnostics.Process process = (System.Diagnostics.Process)sender;
                //System.Diagnostics.Debugger.Break();
            }
    
            private static void Proc_ErrorDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
            {
                Console.Write("0");
                //System.Diagnostics.Process process = (System.Diagnostics.Process)sender;
                //System.Diagnostics.Debugger.Break();
            }
        }
    }
