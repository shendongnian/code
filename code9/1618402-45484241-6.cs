    public class Person
    {
        public string Name { get; set; }
    }
    public class NameValidator
    {
        //This is your assignment, what you called "byref" in the question
        private static Func<Person, string> HowToGetAPersonsName = (person => person.Name);
        //This is what you will be matching the name against
        private static List<String> validNames = new List<string>() { "Bob", "Tom", "Alice" };
        
        public static bool HasValidName(Person myPerson)
        {
            //this dynamically retrieves the property you want
            //FROM the object you supplied afterwards
            string myPersonName = HowToGetAPersonsName.Invoke(myPerson);
            return validNames.Contains(myPersonName); 
        }
    }
    public class ExampleCaller
    {
        public void MyMethod()
        {
            var bob = new Person() { Name = "Bob" };
            if(NameValidator.HasValidName(bob))
            {
                //Valid name!
            }
        }
    }
