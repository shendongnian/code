    public static class StudentRepository
    {
         private static List<Student> students = new List<Student>();
         public static void AddOrUpdateStudent(Student s)
         {
              var stu = students.Where(m=>m.StudentID = s.StudentID).FirstOrDefault();
               if(stu == null)
                {
                    students.Add(s);
                 }
                 else
                 {
                     students.remove(stu);
                     students.Add(s);
                 }
    
         }
    }
