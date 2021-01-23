    public class Employee
        {
            public string Name { get; private set; }
    
            public AvailableClasses Class { get; private set; }
    
            public Employee(string name, string myClass)
            {
                Name = name;
                AvailableClasses classEnum;
                if (!Enum.TryParse(myClass, true, out classEnum))
                    classEnum = AvailableClasses.Other;
    
                Class = classEnum;
            }
        }
    
        public enum AvailableClasses
        {
            Maths,
            Science,
            Other
        }
