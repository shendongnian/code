    public abstract class Person
    {
         public string Name { get; set; }
         public string PhoneNumber { get; set; }
         public static readonly Person Unset = new UnsetPerson();
    }
