    class Program
    {
        static void Main(string[] args)
        {
            var employee = GetInstance<Employee>(Importance.Employee);
            var teacher = GetInstance<Teacher>(Importance.Teacher);
            Console.WriteLine(employee.GetType());
            Console.WriteLine(teacher.GetType());
            Console.ReadKey();
        }
        public static T GetInstance<T>(Importance importance) where T : Role, new()
        {
            if (typeof(T) == typeof(Employee) && importance != Importance.Employee)
            {
                throw new InvalidCastException();
            }
            if (typeof(T) == typeof(Teacher) && importance != Importance.Teacher)
            {
                throw new InvalidCastException();
            }
            return new T();
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
    public enum Importance
    {
        Teacher,
        Employee
    }
