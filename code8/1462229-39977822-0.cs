    static void Main(string[] args)
    {
        //variable name in camelCase.
        //"Holly" is a string
        object holly = CreateObject("Holly", 21);
        //Casting from object to Cat so you can access Age property
        int hollyAge = ((Cat)holly).Age; 
    }
    //Function names EachWorkCapitalized
    public static object CreateObject(string name, int i)
    {
        Cat holly = new Cat(name, i);
        return holly;
    }
    public class Cat
    {
        //If you implement your properties with the default get set behavior better use this form
        public string Name { get; set; }
        public int Age { get; set; }
        public Cat(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
