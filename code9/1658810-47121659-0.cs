    public class Student
    {
        public string Name;
        public string Position;
        public string Intern;
        public string Salary;
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] yourFile = new string[]
            {
                "Name:Bob|Position:CEO|Intern:7|Salary:7000",
                "Name:Toti|Position:Freelancer|Intern:4|Salary:4000"
            };
            
            List<Student> students = new List<Student>();
            
            foreach(string s in yourFile)
            {
                string name;
                string pos;
                string intern;
                string salary;
                
                string[] dividedLines = s.Split('|');
                foreach(string line in dividedLines)
                {                    
                    string[] data = line.Split(':');
                    switch(data[0])
                    {
                        case "Name":
                        name = data[1];
                        break;
                        case "Position":
                        pos = data[1];
                        break;
                        case "Intern":
                        intern = data[1];
                        break;
                        case "Salary":
                        salary = data[1];
                        break;
                    }
                }
            }
        }
    }
