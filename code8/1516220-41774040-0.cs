    private IEnumerator StartAndWaitForProcess()
    {
        bool programFinished = false;
        var waitItem = new WaitUntil(() => programFinished);
        MyProcess = new Process();
        MyProcess.EnableRaisingEvents = true;
        MyProcess.StartInfo.UseShellExecute = false;
        MyProcess.StartInfo.RedirectStandardOutput = true;
        //MyProcess.StartInfo.RedirectStandardInput = true;
        //MyProcess.StartInfo.RedirectStandardError = true;
        MyProcess.StartInfo.FileName = DataPath + "myfile.bat";
        MyProcess.OutputDataReceived += new DataReceivedEventHandler(DataReceived);
        MyProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        MyProcess.StartInfo.CreateNoWindow = true;
    
        //Sets the bool to true when the event fires.
        MyProcess.Exited += (obj, args) => programFinished = true;
     
        MyProcess.Start();
        MyProcess.BeginOutputReadLine();
        //string Output = MyProcess.StandardOutput.ReadToEnd(); //This locks up the UI till the program closes. 
        //UnityEngine.Debug.Log(Output); This log should be in the DataReceived function.
    
        //MyProcess.WaitForExit(); This also locks up the UI
    
        //This waits for programFinished to become true.
        yield return waitItem;
    }
