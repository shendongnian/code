        static void Main(string[] args)
        {
            Employees lijst = new Employees();
            lijst.Add(new Employee("B1", 200));
            lijst.Add(new Employee("B2", 100));
            lijst.Add(new Employee("B3", 300));
            lijst.Wijzig((Employee b) => b.Salary += 100);
            lijst.Print();
            Console.ReadKey();
        }
        class Employee
        {
            public String Name { get; set; }
            public int Salary { get; set; }
            public Employee(String Name, int Salary)
            {
                this.Name = Name;
                this.Salary = Salary;
            }
        }
        class Employees
        {
            // [Delete]
            // public Func<Employee, int> Wijzig = new Func<Employee, int>(Change);
            private ArrayList _lijst = new ArrayList();
            public void Add(Employee e)
            {
                _lijst.Add(e);
            }
            // [Delete]
            //static int Change(Employee b)
            //{
            //    return 0;
            //}
            // [New]
            public void Wijzig(Func<Employee, int> func) 
            {
                foreach (Employee e in _lijst)
                {
                    func(e);
                }
            }
            public void Print() 
            {
                foreach (Employee e in _lijst)
                {
                    Console.WriteLine(e.Name + "\t" + e.Salary);
                }
            }
        }
