     var t = Task.Run(() => {
         Process myProcess = new Process();
         try
         {
             myProcess.StartInfo.UseShellExecute = false;
             // You can start any process, HelloWorld is a do-nothing example.
             myProcess.StartInfo.FileName = "C:\\HelloWorld.exe";
             myProcess.StartInfo.CreateNoWindow = true;
             myProcess.Start();
         }
         catch(Exception ex)
         {
         }
     });
