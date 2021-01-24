    private Process Execute(string vsEnvVar)
        {
            Process process = new Process();
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");//assume location is in path. Otherwise use ComSpec env variable
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardError = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo = psi;
            // attach output events 
            process.ErrorDataReceived += new DataReceivedEventHandler(process_ErrorDataReceived);
            process.OutputDataReceived += new DataReceivedEventHandler(process_OutputDataReceived);
            process.StartInfo = psi;
            process.Start();
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();
            process.StandardInput.WriteLine(string.Format("call \"%{0}%vsvars32.bat\""), vsEnvVar);
            process.StandardInput.Flush();
            return process;
        }
