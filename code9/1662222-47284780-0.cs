     public static void Main(string[] args)
        {
            var initial = InitialSessionState.CreateDefault();
            initial.ImportPSModule(new[] { "BITSTransfer" });
            var runSpace = RunspaceFactory.CreateRunspace(initial);
            runSpace.Open();
            for (int i = 0; i < 5; i++)
            {
                using (Pipeline pipeline = runSpace.CreatePipeline())
                {
                    Command capture = new Command("Get-Command");
                    capture.Parameters.Add("Module", "BITSTransfer");
                    pipeline.Commands.Add(capture);
                        Console.WriteLine(string.Format("In loop {0}", i));
                        System.Collections.ObjectModel.Collection<PSObject> outputCollection = pipeline.Invoke();
                        foreach (PSObject item in outputCollection)
                        {
                            Console.WriteLine(item.BaseObject.ToString());
                        }
                    }
                }
            }
            runSpace.Close();
            Console.ReadLine();
        }
