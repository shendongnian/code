      public class Candidate
        {
        public string Name{get;set;}
        public string Department{get;set;}
        }
        
        public void save(List<Candidate>iolist)
                {          
                    var dir = @"D:\New folder\log";
                    string path = System.IO.Path.Combine(dir, "items1213.txt");
                 
                        File.WriteAllLines(path, iolist.Select(o => o.Name + " " + o.Department
                 ));
           
           
            }
