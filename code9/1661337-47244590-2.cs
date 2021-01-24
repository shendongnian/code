    class Program
    {
            static void Main(string[] args)
            {
                List<StudentsList> stu = new List<StudentsList>();
    
                StudentsList student = new StudentsList();
                student.name = "Abdul Basit Mehmood";
                student.fname = "Abdul";
                stu.Add(student); 
                JavaScriptSerializer js = new JavaScriptSerializer(); 
                var serializedValue = js.Serialize(stu); 
             }
    }
    
    class StudentsList
    {
        public string name;
        public string fname;
    }
