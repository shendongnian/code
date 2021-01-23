    bool status = false;
    Process myProcess;
    private void button1_Click(object sender, EventArgs e) {
        if (status != true) {
            myProcess = new Process()
            status = true;
            // Start a process to print a file and raise an event when done.
            myProcess.StartInfo.FileName = "C:\\Users\\David\\Desktop\\Test\\Test.exe";
            myProcess.Exited += new EventHandler(Process_Exited);
            myProcess.Start();
        }
    }
    private void Process_Exited(object sender, System.EventArgs e) {
        status = false;
    }
