    public class Person
    {
        private string name = "John";
        public Person(string name)
        {
            // The parameter is named `name` and the field is named `name` 
            // so the compiler is going to choose the closest variable.
            // In this case, it will assign `name` parameter to itself.
            // Visual Studio is nice, in this case, to give you a warning but 
            // your code will compile and the compiler will just assign `name`
            // to `name`
            name = name;
            // If you did this: this.name = name; 
            // then the private field will be assigned the value of the parameter
        }
    }
