     public class SmbFileContainer
        {
            private readonly NetworkCredential networkCredential;
            // Path to shared folder:
            private readonly string networkPath;
    
            public SmbFileContainer()
            {
                this.networkPath = @"\\MY_PC\SharedFolder";
                var userName = "Bob";
                var password = "123";
                var domain = "";
                networkCredential = new NetworkCredential(userName, password, domain);
            }
    
            public bool IsValidConnection()
            {
                using (var network = new NetworkConnection($"{networkPath}", networkCredential))
                {
                    var result = network.Connect();
                    return result == 0;
                }
            }
    
            public void CreateFile(string targetFile, string content)
            {
                using (var network = new NetworkConnection(networkPath, networkCredential))
                {
                    network.Connect();
                    var file = Path.Combine(this.networkPath, targetFile);
                    if (!File.Exists(file))
                    {
                        using (File.Create(file)) { };
                        using (StreamWriter sw = File.CreateText(file))
                        {
                            sw.WriteLine(content);
                        }
                    }
                }
            }
        }
