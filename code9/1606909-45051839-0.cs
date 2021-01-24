    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                //run Login-AzureRmAccount
                Runspace runspace = RunspaceFactory.CreateRunspace();
    
                runspace.Open();
    
                Pipeline pipeline = runspace.CreatePipeline();
    
                var scriptText = "Login-AzureRmAccount";
                pipeline.Commands.AddScript(scriptText);
    
                pipeline.Commands.Add("Out-String");
    
                Collection<PSObject> results = pipeline.Invoke();
    
    
                runspace.Close();
    
                StringBuilder stringBuilder = new StringBuilder();
                foreach (PSObject obj in results)
                {
                    stringBuilder.AppendLine(obj.ToString());
                }
    
                var accountinfo = stringBuilder.ToString();
    
                Console.WriteLine(accountinfo);
    
    
                //run Get-AzureRmMetricDefinition
    
                Runspace runspace1 = RunspaceFactory.CreateRunspace();
    
                runspace1.Open();
    
                Pipeline pipeline1 = runspace1.CreatePipeline();
    
                var subscription = "xxxxxxxxxxxx";
                var resourcegroup = "xxxxx";
                var appname = "xxxxx";
    
                //Get metric definitions with detailed output
                var MetricDefscriptText = $"Get-AzureRmMetricDefinition -ResourceId '/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/microsoft.web/sites/{appname}' -DetailedOutput";
                pipeline1.Commands.AddScript(MetricDefscriptText);
    
    
                pipeline1.Commands.Add("Out-String");
    
                Collection<PSObject> Metrics = pipeline1.Invoke();
    
    
                runspace1.Close();
    
                StringBuilder stringBuilder1 = new StringBuilder();
                foreach (PSObject obj in Metrics)
                {
                    stringBuilder1.AppendLine(obj.ToString());
                }
    
                var metricdefinitions = stringBuilder1.ToString();
                Console.WriteLine(metricdefinitions);
            }
        }
    }
