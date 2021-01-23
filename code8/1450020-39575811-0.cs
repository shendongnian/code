    public static void Main(string[] args)
            {            
                Dictionary<string, List<string>> dt = new Dictionary<string, List<string>>();        
    
                using(XmlReader reader = XmlReader.Create(@"data.xml")){
                    bool incomingDd = false;
                    while(reader.Read()){
                        switch(reader.NodeType){
                            case XmlNodeType.Element:                            
                                if(String.Equals(reader.Name, "dt", StringComparison.OrdinalIgnoreCase)){
                                    dt.Add(reader.GetAttribute("id"), new List<string>());
                                }
                                else if(String.Equals(reader.Name, "dd", StringComparison.OrdinalIgnoreCase)){
                                    incomingDd = true;                                
                                }
                                break;
                            case XmlNodeType.Text:                                
                                if(incomingDd && !String.IsNullOrEmpty(reader.Value)){                                
                                    dt.Values.ElementAt(dt.Count -1).Add(reader.Value);
                                    incomingDd = false;
                                }
                                break;
                        }
                    }
                }
    
                foreach(var item in dt){
                    Console.WriteLine($"{item.Key} {item.Value.Count()}: \n");
                    foreach(var dd in item.Value){
                        System.Console.WriteLine($"\t{dd}");
                    }
                }
            }
