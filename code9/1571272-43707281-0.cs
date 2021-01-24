    class Program
    {
        static void Main(string[] args)
        {
            ITDepartment emp = new ITDepartment();
            // Give Details for the user to DisplayItEmployee() method. 
            emp.DisplayItEmployee("Jhon","Foo",DateTime.Now, "Male",10,DateTime.Today, "Head","deparment");
            emp.DisplayItEmployee("Jhon2","Foo2",DateTime.Now, "Male2",11,DateTime.Today, "Head2","deparment2");
            Console.ReadKey();
        }
    }
    public class Employee
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public double StaffMenember { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public void DisplayEmployee()
        {
            // Display user props to console
            Console.WriteLine($"FirstName: {FirstName}\nLastName: {LastName}\nBirthDate: {BirthDate}\nGender: {Gender}\nStaffMenember: {StaffMenember}\nDateOfEmployment: {DateOfEmployment}\nPosition: {Position}\nDepartment: {Department}");
        }
    }
    class ITDepartment : Employee
    {
        public void DisplayItEmployee(string firstName, string lastName, DateTime birthDate, string gender, double member, DateTime deployment, string position, string department)
        {
            // initialize employee with passed in details
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
            StaffMenember = member;
            DateOfEmployment = deployment;
            Position = position;
            Department = department;
            // call the method that will display the information
            DisplayEmployee();
        }
    }
