    using System;
    using System.Management.Automation;
    using Cassia;
    
    namespace CassiaCmdlet
    {
        [Cmdlet("Get", "TsSession")]
        public class GetTsSession : Cmdlet
        {
            [Parameter(Position = 0)]
            [Alias("ServerName", "MachineName", "Name")]
            public string ComputerName { get; set; }
            /// <summary>
            /// Processes the record.
            /// </summary>
            protected override void ProcessRecord()
            {
                using (var server = GetServer())
                {
                    server.Open();
                    foreach (var session in server.GetSessions())
                    {
                        WriteObject(session);
                    }
                    server.Close();
                }
            }
    
            private ITerminalServer GetServer()
            {
                var mgr = new TerminalServicesManager();
                if (string.IsNullOrWhiteSpace(ComputerName))
                { 
                    // Local Machine
                    return mgr.GetLocalServer(); 
                }
                else
                {
                    // Remote Machine
                    return mgr.GetRemoteServer(ComputerName);
                }
            }
        }
    }
