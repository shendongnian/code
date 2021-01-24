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
            string[] yourFile = System.IO.File.ReadAllLines(@"C:PathToFile\File.txt");
            
            List<Student> students = new List<Student>();
            
            foreach(string s in yourFile)
            {
                Student student = new Student();
                
                string[] dividedLines = s.Split('|');
                foreach(string line in dividedLines)
                {                    
                    string[] data = line.Split(':');
                    switch(data[0])
                    {
                        case "Name":
                        student.Name = data[1];
                        break;
                        case "Position":
                        student.Position = data[1];
                        break;
                        case "Intern":
                        student.Intern= data[1];
                        break;
                        case "Salary":
                        student.Salary = data[1];
                        break;
                    }
                }
                students.Add(student);
            }
        }
    }
