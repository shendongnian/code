    class Program
    {
        static void Main(string[] args)
        {
            var servers = new Dictionary<string, Server>(); // parse results are here
            using (var fs = File.OpenRead(@"G:\tmp\so\parse.txt")) {
                using (var reader = new StreamReader(fs)) {
                    string line;
                    Server current = null;                    
                    while ((line = reader.ReadLine()) != null) {
                        // line break - end of server definition
                        if (String.IsNullOrWhiteSpace(line)) {
                            if (current != null) {
                                servers.Add(current.Name, current);
                                current = null;
                            }
                            continue;
                        }
                        var cidx = line.IndexOf(':'); // split by colon
                        if (cidx >= 0) {
                            var name = line.Substring(0, cidx).Trim();
                            var value = line.Substring(cidx + 1).Trim();
                            // ugly switch
                            switch (name) {
                                case "Server":
                                    current = new Server() {Name = value};
                                    break;
                                case "ERROR 0":
                                    if (current == null)
                                        throw new Exception("Invalid line"); // more details here, just example
                                    current.Error0 = int.Parse(value);
                                    break;
                                case "ERROR 3":
                                    if (current == null)
                                        throw new Exception("Invalid line"); // more details here, just example
                                    current.Error3 = int.Parse(value);
                                    break;
                                case "ERROR 4":
                                    if (current == null)
                                        throw new Exception("Invalid line"); // more details here, just example
                                    current.Error4 = int.Parse(value);
                                    break;
                                case "ERROR 8":
                                    if (current == null)
                                        throw new Exception("Invalid line"); // more details here, just example
                                    current.Error8 = int.Parse(value);
                                    break;
                                case "ERROR 9":
                                    if (current == null)
                                        throw new Exception("Invalid line"); // more details here, just example
                                    current.Error9 = int.Parse(value);
                                    break;
                            }
                        }
                        else {
                            var tdix = line.IndexOf('|');
                            if (tdix >= 0) {
                                var name = line.Substring(0, tdix).Trim();
                                var value = line.Substring(tdix + 1).Trim();
                                if (servers.ContainsKey(name)) {
                                    servers[name].CronJobErrors.Add(value);
                                }
                            }
                        }
                    }
                }
            }            
        }        
    }
        
