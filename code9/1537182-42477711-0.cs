    static void Main(string[] args)
    {
        string line = null;
        Student student = null;
        IList<Student> students = new List<Student>();
        using (var fileReader = new StreamReader(fileName))
        {
            while ((line = fileReader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue; //continue execution on extra lines
                if(line.StartsWith("Student...", StringComparison.CurrentCultureIgnoreCase))
                {
                    student = new Student();
                    students.Add(student);
                }
    
                if (student != null)
                    student.Lines.Add(line);
    
    
            }
    
            fileReader.Close();
        }
    }
    
    class Student
    {
        public IList<string> Lines { get; } = new List<string>();
    }
