    public void Run(string command) {
            System.Diagnostics.ProcessStartInfo to_run = new System.Diagnostics.ProcessStartInfo();
            to_run.FileName =  "cmd";
            to_run.Arguments = "/c "+ command;
            to_run.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden; //Hidden cmd
            //Start a process based on to_run description
            System.Diagnostics.Process executing = System.Diagnostics.Process.Start(to_run); 
            executing.WaitForExit(); //Don't go further until this function is finished
    }
