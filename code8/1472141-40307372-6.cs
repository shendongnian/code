    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = GetInstance<Employee>(Importance.Employee);
            Teacher teacher = GetInstance<Teacher>(Importance.Teacher);
            Console.WriteLine(employee.GetType());
            Console.WriteLine(teacher.GetType());
            Console.ReadKey();
        }
        public static T GetInstance<T>(Importance objType)
        {
            if (objType == Importance.Employee)
                return (T)Convert.ChangeType((new Employee()), typeof(T));
            else
                return (T)Convert.ChangeType((new Teacher()), typeof(T));
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
    enum Importance
    {
        Employee,
        Teacher
    };
