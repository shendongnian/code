    public class Chip<T>
    {
        public T FamilyType;
    }
    public class ChipOne
    {
        //properties
    }
    public class ChipTwo
    {
        //properties
    }
    // If creating Chip of type ChipOne manually
    var chip1 = new Chip<ChipOne>();
    //Accessing some property
    //chip1.FamilyType.someProperty
