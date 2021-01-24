    if (P.Start()){
        DateTime endTime = DateTime.Now.AddSeconds(5);
        while(!P.HasExited){
            readData = P.StandardOutput.ReadLine(); // This will also wait for the  process to at least close its stdout
            // Process your line here
            if (endTime > DateTime.Now)
                P.Kill();
        }
    }
