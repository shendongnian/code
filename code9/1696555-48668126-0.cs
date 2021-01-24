    System.Diagnostics.Process process = new System.Diagnostics.Process();
    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(); 
    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    startInfo.FileName = "test.exe";
    process.StartInfo = startInfo;
    process.Exited += (sender, e) => {
     	pictureBoxOutput.Image = ...;
        MessageBox.Show("C Sharp is awesome.");
    
    };
    process.Start();
