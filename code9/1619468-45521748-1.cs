                     ps.Add(new ParsedData()
                     {
                         IP = cols[0]!=null?cols[0]:"", //and check if inside it's content..
                         Port = cols[1],
                         Username = cols[2],
                         Password = cols[3]
                     });
                 });
    
                foreach(ParsedData p in ps)
                {
                    Console.WriteLine(p.IP + "\t" + p.Port + "\t" + p.Username + "\t" + p.Password);
                }
    
            }
        }
        public class ParsedData
        {
            public string IP { get; set; }
            public string Port { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }
