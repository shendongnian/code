    class Program
    {
        static void Main(string[] args)
        {           
            //assume this main function is your insert button click event. Then
            Employee objEmployee = new Employee() { Address = txtAddress.Text, Age = Convert.ToInt32(txtAge.Text), Name = txtEmpName.Text, Salary = Convert.ToDouble(txtSal.Text) };
            DATA_MANIPULATION.ADD_VALUES(objEmployee);
            Console.ReadLine();
        }
    }
    public class Employee
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Salary { get; set; }
        public int Age { get; set; }
    }
    public class DATA_MANIPULATION
    {
        public static void ADD_VALUES(Employee objEmployee)
        {
            //code to insert data in the DB
        }
    }
