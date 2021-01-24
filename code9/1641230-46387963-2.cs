    Process process = new Process(proc);
    process.Start();
    while (!process.StandardOutput.EndOfStream) {
        System.Diagnostics.Debug.Write(process.StandardOutput.ReadLine());
    }
    
