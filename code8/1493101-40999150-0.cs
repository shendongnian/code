    public class Employee
    {
        public string Name { get; set; }
        public Employee Boss
        {
            get { return _boss; }
            set
            {
                _boss?.RemoveJunior(this);
                value?.AddJunior(this);
            }
        }
        public IReadOnlyList<Employee> Juniors => _juniors.AsReadOnly();
        private Employee _boss = null;
        private readonly List<Employee> _juniors = new List<Employee>();
        public Employee(string name)
        {
            Name = name;
        }
        public void AddJunior(Employee e)
        {
            // Remove from existing boss' list of employees
            // Can't set Boss property here, that would create infinite loop
            e._boss?.RemoveJunior(e);
            _juniors.Add(e);
            e._boss = this;
        }
        public void RemoveJunior(Employee e)
        {
            _juniors.Remove(e);
            e._boss = null;
        }
    }
    public class EmployeeTests
    {
        [Fact]
        public void SettingBoss_AddsToEmployee()
        {
            var b = new Employee("boss");
            var e1 = new Employee("1");
            e1.Boss = b;
            Assert.Same(b, e1.Boss);
            Assert.Contains(e1, b.Juniors);
        }
        [Fact]
        public void AddEmployee_SetsBoss()
        {
            var b = new Employee("boss");
            var e1 = new Employee("1");
            b.AddJunior(e1);
            Assert.Same(b, e1.Boss);
            Assert.Contains(e1, b.Juniors);
        }
        [Fact]
        public void NullBoss_RemovesEmployee()
        {
            var b = new Employee("boss");
            var e1 = new Employee("1");
            b.AddJunior(e1);
            e1.Boss = null;
            Assert.Null(e1.Boss);
            Assert.DoesNotContain(e1, b.Juniors);
        }
        [Fact]
        public void RemoveEmployee_NullsBoss()
        {
            var b = new Employee("boss");
            var e1 = new Employee("1");
            b.AddJunior(e1);
            b.RemoveJunior(e1);
            Assert.Null(e1.Boss);
            Assert.DoesNotContain(e1, b.Juniors);
        }
    }
