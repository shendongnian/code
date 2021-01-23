	public class Logger
    {
        public static void Log(string message)
        {
            Console.WriteLine("EF Message: {0} ", message);
        }
    }
	class EF6Demo
    {
    
        public static void DBCommandLogging()
        {
            using (var context = new SchoolDBEntities())
            {
                
                context.Database.Log =  Logger.Log;                
                var student = context.Students
                                .Where(s => s.StudentName == "Student1").FirstOrDefault<Student>();
                student.StudentName = "Edited Name";
                context.SaveChanges();
            }
        }
	}
