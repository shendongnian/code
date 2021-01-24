    static void Main() {
        string strCmdText3;
        strCmdText3 = "/c arp -a";
        Process process = new Process();
        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.Arguments = strCmdText3;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.CreateNoWindow = true;
        process.Start();
        //* Read the output (or the error)
        string output = process.StandardOutput.ReadToEnd();
        //Console.WriteLine(output);
        //string err = process.StandardError.ReadToEnd();
        //Console.WriteLine(err);
        process.WaitForExit();
        //show.Text = output;
        string[] LinesReturned = output.Split( '\n' );
        List<string> ipAddresses = new List<string>();
        for (int i = 3; i < LinesReturned .GetUpperBound(0); i++) {
        ipAddresses.Add(LinesReturned [i].Substring(2, 15).Trim());
    }
