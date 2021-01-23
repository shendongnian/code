            using (Runspace runspace = RunspaceFactory.CreateRunspace(RunspaceConfiguration.Create()))
            {
                runspace.Open();
                using (Pipeline pipeline = runspace.CreatePipeline())
                {
                    Command scriptCommand = new Command(psScript);
                    scriptCommand.Parameters.Add(new CommandParameter("Username", "user"));
                    scriptCommand.Parameters.Add(new CommandParameter("Password", "password"));
                    scriptCommand.Parameters.Add(new CommandParameter("Server", server));
                    scriptCommand.Parameters.Add(new CommandParameter("Script", script));
                    pipeline.Commands.Add(scriptCommand);
                    var results = pipeline.Invoke();
                    foreach (var item in results)
                    {
                        Console.WriteLine("Output: {0}", item);
                    }
                }
            }
