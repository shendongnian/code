    public class AnimalIdAttribute : Attribute
    {
         public AnimalIdAttribute(string id)
         {
               Id = id;
         }
    
         public string Id { get; }
    }
    public class Animal 
    {
         public string Id => this.GetCustomAttribute<AnimalIdAttribute>(true)?.Id;
    }
    [AnimalId("dog")]   
    public class Dog : Animal
    {
    }
