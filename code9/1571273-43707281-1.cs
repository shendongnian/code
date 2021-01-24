    class Program
    {
        public static ItDepartment ItDepartment = new ItDepartment();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Press l for emoloyee list");
                Console.WriteLine("Press a for adding a employee");
                Console.WriteLine("Press x for closing program");
                // Get pressed key and take action
                switch (Console.ReadKey().KeyChar)
                {
                    case 'a':
                        Console.Clear();
                        ItDepartment.Add();
                        break;
                    case 'l':
                        Console.Clear();
                        ItDepartment.PrintItDepartmentEmployees();
                        break;
                    case 'x':
                        return;
                    default:
                        Console.WriteLine("Not a vallid key");
                        break;
                }
            }
        }
    }
    public class Employee
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Gender { get; private set; }
        public double StaffMenember { get; private set; }
        public DateTime DateOfEmployment { get; private set; }
        public string Position { get; private set; }
        public string Department { get; private set; }
        
        public void SetUser()
        {
            Console.WriteLine("Enter First Name for employee");
            FirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name for employee");
            LastName = Console.ReadLine();
            Console.WriteLine("Enter department for employee");
            Department = Console.ReadLine();
            Console.WriteLine("Enter position for employee");
            Position = Console.ReadLine();
            Console.WriteLine("Enter BirthDate for employee");
            BirthDate = GetDate();
            Console.WriteLine("Enter DateOfEmployment for employee");
            DateOfEmployment = GetDate();
            Console.WriteLine("Enter gender for employee");
            Gender = Console.ReadLine();
            StaffMenember = Program.ItDepartment.TotalEmployees();
        }
        private DateTime GetDate()
        {
            // 1. Ask the user to enter a date. 
            // 2. If it can't be converted to date like '132' it will try again and ask for the date ect..
            // 3. If success return date
            DateTime time;
            int counter = 0;
            do
            {
                if (counter != 0)
                {
                    Console.WriteLine("Could not convert input to date try again...");
                }
                time = StringToDate(Console.ReadLine());
                counter++;
            } while (time == DateTime.MinValue);
            return time;
        }
        private DateTime StringToDate(string input)
        {
            // 1. Get string input and try to convert it to a date.
            // 2. If it fails return the minimum version of datetime so we know it is wrong and can't be parsed
            return DateTime.TryParse(input, out DateTime date) ? date : DateTime.MinValue;
        }
        
        public override string ToString()
        {
            // Return a string of all the fiels in the current employee
            return $"FirstName: {FirstName}\nLastName: {LastName}\nBirthDate: {BirthDate}\nGender: {Gender}\nStaffMenember: {StaffMenember}\nDateOfEmployment: {DateOfEmployment}\nPosition: {Position}\nDepartment: {Department}\n";
        }
    }
    class ItDepartment
    {
        private List<Employee> _employees;
        public ItDepartment()
        {
            _employees = new List<Employee>();
        }
        public void Add()
        {
            // Create employee
            Employee emp = new Employee();
            // Call the method SetUser in Employee class
            emp.SetUser();
            // When the information is set add the employee object to the list
            _employees.Add(emp);
        }
        public void PrintItDepartmentEmployees()
        {
            // loop thrue all employees in the list and call method to string withs will return a string of the employee.
            foreach (var emp in _employees)
            {
                Console.WriteLine("================================================================================");
                // Write the string to the console.
                Console.WriteLine(emp.ToString());
            }
        }
        public int TotalEmployees()
        {
            // returns the total of employees in the list for the staff member.
            return _employees.Count;
        }
    }
