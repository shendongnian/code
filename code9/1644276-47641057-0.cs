    fileName = @"D:\temp\FaxTest.pdf";
    faxDoc.Sender.Name = faxRec.From;
    faxDoc.Sender.Company = faxRec.From;
    faxDoc.Body = fileName;
    faxDoc.Subject = faxRec.ReferenceId;
    faxDoc.DocumentName = faxRec.ReferenceId;
    var to = "xxxxxxxxxx";
    faxDoc.Recipients.Add(to, "Some Name");
    var serverName = Environment.MachineName;
    var myProcesses = Process.GetProcessesByName("AcroRd32");
    foreach (var myProcess in myProcesses)
    {
        if (DateTime.Now.Ticks - myProcess.StartTime.Ticks > TimeSpan.FromSeconds(30).Ticks) {
            myProcess.Kill();
        }
    }
    string[] returnVal = faxDoc.Submit(serverName);
