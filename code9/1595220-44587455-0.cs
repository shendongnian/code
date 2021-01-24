        public class Employee
        {
            public string Name { get; set; }
            // ...
            public override string ToString()
            {
                return string.Format("Employee: {0}", Name);
            }
        }
        public class Manager : Employee
        {
            public override string ToString()
            {
                return string.Format("Manager: {0}", Name);
            }
        }
