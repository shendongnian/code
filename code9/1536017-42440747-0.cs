    class Parent
    {
        public Child Child1 { get; set; }
        public Child Child2 { get; set; }
        public Child Child3 { get; set; }
    }
    public class Child
    {
        public string Name { get; set; }
    }
    public class Tests
    {
        public void Test()
        {
            var parent = new Parent();
            parent.Child1 = new Child() { Name = "Child1" };
            parent.Child2 = new Child() { Name = "Child2" };
            parent.Child3 = new Child() { Name = "Child3" };
            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static;
            var names = "";
            parent.GetType() 
                .GetProperties(bindingFlags) //Gets All Properties where the bindingFlags are matching
                .Where(w => w.PropertyType == typeof(Child)) //Filters all properties to type of Child
                .ForEach(property => //Then foreach Child Property
                {
                    property.GetType()
                        .GetProperties(bindingFlags) //Gets All Properties where the bindingFlags are matching
                        .Where(w => w.Name == "Name") //Filters all properties to Name of 'Name'
                        .ForEach(value => //Then foreach found Property
                        {
                            names += value.GetValue(property); //Gets the Value of Name Property
                        });
                });
            Console.Write(names);
        }
    }
