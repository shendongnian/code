    var sc = new System.ServiceProcess.ServiceController("MyService", "MyRemoteMachine");
    sc.Start();
    sc.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running);
    sc.Stop();
    sc.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Stopped);
