    public class Employee
    {
        private string firstName;
        private string lastName;
        private string phone;
        //This could be turned into a class or a enum, e.g. Roles for more complex scenarios
        private string position;
        private string team;
        //You can add a constructor if you want to make sure a position is always provided, but it would be better to handle this at the database level by setting the column as NOT NULL
        public Employee(string position)
        {
             this.position = position;
        }
       
        //Public properties omitted for brevity
    }
