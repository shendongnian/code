    public class Person
    {
        public string State { get; set; }
        public string Gender { get; set; }
        public bool Married { get; set; }   
        public bool SalaryUnderHundredDollar { get; set; }
    }
    public class SchemeBuilder
    {
        public List<Func<int>> BuildScheme(Person person)
        {
            return new List<Func<int>>
            {
                ()=> person.State=="Florida" || person.State=="NewYork" ? 100 : 0,
                ()=> person.Gender=="Male" ? 110 : 0,
                ()=>person.Married ? 200 : 0,
                ()=>person.SalaryUnderHundredDollar ? 500 :0
            };
        }
    }
    public class TestClass
    {
        public void Main()
        {
            Person person = new Person();
            person.State = "NewYork";
            person.Gender = "Female";
            person.Married = true;
            person.SalaryUnderHundredDollar = true;
            List<int> listOfSchemesEligble = new List<int>();
            var builder = new SchemeBuilder();
            var schemes = builder.BuildScheme(person);
            foreach(var scheme in schemes)
            {
                var eleigiblePoints = scheme();
                if (eleigiblePoints != 0)
                    listOfSchemesEligble.Add(eleigiblePoints);
            }
        }
    }
