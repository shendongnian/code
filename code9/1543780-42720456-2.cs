    using System;
    using System.Text;
    using Microsoft.SqlServer.Management.IntegrationServices;
    using System.Data.SqlClient;
    using System.Collections.ObjectModel;
    
    namespace C_junk
    {
        public class PackageExecuter
        {
            public string Catalog { get; set; }         
            public string Folder { get; set; }
            public string Project { get; set; }
            public string Package { get; set; } 
            public string SsisConnString { get; set; }
   
            public string Execute()
            {
                SqlConnection ssisServer = new SqlConnection(this.SsisConnString);
                var ssis = new IntegrationServices(ssisServer);
                var package = ssis
                        .Catalogs[this.Catalog]
                        .Folders[this.Folder]
                        .Projects[this.Project]
                        .Packages[this.Package];
                var setValueParameters = new Collection<PackageInfo.ExecutionValueParameterSet>();
                setValueParameters.Add(new PackageInfo.ExecutionValueParameterSet
                {
                    ObjectType = 50,
                    ParameterName = "SYNCHRONIZED",
                    ParameterValue = 1
                });
                var executionId = package.Execute(true, null, setValueParameters);
                Catalog catalog = new Catalog(ssis);
                var execution = catalog.Executions[executionId];
    
                return GetMessages(execution.Messages);
            }
    
            private static string GetMessages(OperationMessageCollection messages)
            {
                StringBuilder logMessages = new StringBuilder();
                foreach (var message in messages)
                {
                    string logMessage = String.Format(@"Message id: {0}. {1} - Type: {2}: {3}"
                                        , message.Id
                                        , message.MessageTime
                                        , GetMessageType(message.MessageType)
                                        , message.Message);
                    logMessages.AppendLine(logMessage);
                }
    
                return logMessages.ToString();
            }
    
            private static string GetMessageType(short? typeId)
            {
                string messageType = "";
                switch (typeId)
                {
                    case 120:
                        messageType = "Error";
                        break;
                    case 110:
                        messageType = "Warning";
                        break;
                    case 70:
                        messageType = "Information";
                        break;
                    case 10:
                        messageType = "Pre-validate";
                        break;
                    case 20:
                        messageType = "Post-validate";
                        break;
                    case 30:
                        messageType = "Pre-execute";
                        break;
                    case 40:
                        messageType = "Post-execute";
                        break;
                    case 60:
                        messageType = "Progress";
                        break;
                    case 50:
                        messageType = "StatusChange";
                        break;
                    case 100:
                        messageType = "QueryCancel";
                        break;
                    case 130:
                        messageType = "TaskFailed";
                        break;
                    case 90:
                        messageType = "Diagnostic";
                        break;
                    case 200:
                        messageType = "Custom";
                        break;
                    case 140:
                        messageType = "DiagnosticEx";
                        break;
                    case 400:
                        messageType = "NonDiagnostic";
                        break;
                    case 80:
                        messageType = "VariableValueChanged";
                        break;
                }
                return messageType;
            }
        }
    }
