    class Program
    {
        static void Main(string[] args)
        {
            var employee = GetInstance<Employee>();
            var teacher = GetInstance<Teacher>();
            Console.WriteLine(employee.GetType());
            Console.WriteLine(teacher.GetType());
            Console.ReadKey();
        }
        public static T GetInstance<T>() where T : Role, new()
        {
            var role = new T();
            // do something important here
            return role;
        }
    }
    public abstract class Role { }
    public class Employee : Role
    {
        string ID = "";
        string Name = "";
    }
    public class Teacher : Role
    {
        string ID = "";
        string Name = "";
    }
