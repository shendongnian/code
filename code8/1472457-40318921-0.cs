    public class IdHolder
    {
        public int Id { get; set; }
    }
    public class Person : IdHolder
    {
        // Person inherits the 'Id' property from IdHolder
        // other properties unique to person...
    }
