    class Program
    {
        static void Main(string[] args)
        {
            var t = typeof(Animal);
            foreach (MemberInfo item in t.GetMembers(BindingFlags.Static | BindingFlags.Public))
            {
                if (Attribute.IsDefined(item, typeof(FourLeggendAttribute)))
                {
                    // do something
                }
            }
        }
    }
    public enum Animal
    {
        [FourLeggend]
        Dog,
        [FourLeggend]
        [AnotherOne]
        Cat,
        [FourLeggend]
        Mouse,
        [AnotherOne]
        Ant,
        Monkey
    }
    public class AnotherOneAttribute : Attribute
    {
    }
    public class FourLeggendAttribute : Attribute
    {
    }
 
