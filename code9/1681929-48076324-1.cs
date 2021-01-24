    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello World");
            Response res = new Response { Dictionary = new Dictionary<string, Employee>() };
            Employee firstEmployee = new Employee { Name = "John Doe", Id = "1111", Seniority = 2 };
            Employee secondEmployee = new Employee { Name = "Jane Doe", Id = "9999", Seniority = 10 };
            firstEmployee.Cars.Add(new Car { OwnerId = "1111", Model = "Chevrolet Spark", RegistrationPlate = "LTO1234" });
            firstEmployee.Cars.Add(new Car { OwnerId = "1111", Model = "Chevrolet Malibu", RegistrationPlate = "LTO5678" });
            secondEmployee.Cars.Add(new Car { OwnerId = "9999", Model = "Mercedes Benz", RegistrationPlate = "ABC1234" });
            secondEmployee.Cars.Add(new Car { OwnerId = "9999", Model = "Mercedes Maybach", RegistrationPlate = "ABC5678" });
            res.Dictionary.Add(firstEmployee.Name, firstEmployee);
            res.Dictionary.Add(secondEmployee.Name, secondEmployee);
            var result = JsonConvert.SerializeObject(res);
            Console.WriteLine(result);
        }
    }
    public class Response
    {
        public Dictionary<string, Employee> Dictionary { get; set; }
        public class Employee : TypeConverter
        {
            public Employee(string name, decimal seniority, string id, List<Car> cars)
            {
                Name = name;
                Seniority = seniority;
                Id = id;
                Cars = cars;
                Cars = new List<Car>();
            }
            public Employee()
            {
                Cars = new List<Car>();
            }
            public string Name { get; set; }
            public string Id { get; set; }
            public decimal Seniority { get; set; }
            public List<Car> Cars { get; set; }
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                if (sourceType == typeof(string))
                {
                    return true;
                }
                return base.CanConvertFrom(context, sourceType);
            }
            public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
            {
                if (destinationType == typeof(string))
                {
                    return ((Employee)value).Name + "," + ((Employee)value).Id + "," + ((Employee)value).Seniority;
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }
        public class Car
        {
            public string OwnerId { get; set; }
            public string Model { get; set; }
            public string RegistrationPlate { get; set; }
        }
    }
