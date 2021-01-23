    var jsonData = "[{\"UserId\":\"5656\",\"TestId\":\"562\",\"UserName\":\"testuser\",\"Data1\":\"dang\",\"Data2\":\"phy\",\"Data3\":\"right\",\"Data4\":\"left\",\"Data5\":\"top\",\"Data6\":\"abc\",\"Data7\":\"rat\",\"Data8\":\"test\",\"Data9\":\"91\",\"Data10\":\"9090\"},{\"UserId\":\"8989\",\"TestId\":\"12\",\"UserName\":\"abc\",\"Data1\":\"111\",\"Data2\":\"222\",\"Data3\":\"Pwww\",\"Data4\":\"aaa\",\"Data5\":\"bbbb\",\"Data6\":\"cc\",\"Data7\":\"ooo\",\"Data8\":\"hh\",\"Data9\":\"g\",\"Data10\":\"5656\"}]";
    
                var data = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonData);
    
                Console.WriteLine("Total : {0}", data.Count);
                Console.WriteLine("Item1 Total : {0}", data[0].Count);
                Console.WriteLine("Item2 Total : {0}", data[1].Count);
    
                foreach(var item in data)
                {
                    Console.WriteLine("--- Propertie start-----");
                    foreach(var kvPair in item)
                    {
                        Console.WriteLine("property name : {0}", kvPair.Key);
                        Console.WriteLine("property value : {0}", kvPair.Value);
                    }
                    Console.WriteLine("--- Propertie end-----");
                }
    
                Console.ReadLine();
