    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Management;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Create a runspace.
                using (Runspace myRunSpace = RunspaceFactory.CreateRunspace())
                {
                    myRunSpace.Open();
                    using (PowerShell powershell = PowerShell.Create())
                    {
                        // Create a pipeline with the Get-Command command.
                        powershell.AddScript("Set-ExecutionPolicy -Scope Process -ExecutionPolicy Unrestricted");
                        powershell.AddScript(@"C:\Users\you\Desktop\a.ps1");
                        // add an extra command to transform the script output objects into nicely formatted strings
                        // remove this line to get the actual objects
                        powershell.AddCommand("Out-String");
                        // execute the script
                        var results = powershell.Invoke();
                        powershell.Streams.ClearStreams();
                        powershell.Commands.Clear();    
                        // convert the script result into a single string
                        StringBuilder stringBuilder = new StringBuilder();
                        foreach (PSObject obj in results)
                        {
                            stringBuilder.AppendLine(obj.ToString());
                        }
                        Console.WriteLine(stringBuilder.ToString());
                    }
                }
            }
        }
    }
