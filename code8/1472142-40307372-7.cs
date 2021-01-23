    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = GetInstance<Employee>();
            Teacher teacher = GetInstance<Teacher>();
            Console.WriteLine(employee.GetType());
            Console.WriteLine(teacher.GetType());
            Console.ReadKey();
        }
        public static T GetInstance<T>() where T : class, new()
        {
            return new T();
        }
    }
    public class Employee
    {
        string ID = "";
        string Name = "";
    }
    public class Teacher
    {
        string ID = "";
        string Name = "";
    }
