    public static void ReadInventory()
            {
                XDocument doc = XDocument.Load(@"D:\\Sample\\Data2.xml");
                XNamespace ns = doc.Root.Name.Namespace; // You will need to use this "ns" in every XPATH except attributes. 
                var v = from h in doc.Descendants(ns+"StatusApplicationControl")
                        select new StatusApplicationControl
                        {
                            Start = h.Attribute("Start").Value,
                            End = h.Attribute("End").Value
                        };
    
                foreach (var item in v)
                {
                    Console.Write("Start" + item.Start + " End " + item.End + "\r\n" );
                }
    
                Console.WriteLine(v.Count());
            }
