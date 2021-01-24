    public class Class1 : Interface1, Interface2
    {
        // Note the lack of access modifier here. That's important!
        Data Interface1.GetData()
        {
            // Implementation for Interface1
        }
        Data Interface2.GetData()
        {
            // Implementation for Interface2
        }
    }
