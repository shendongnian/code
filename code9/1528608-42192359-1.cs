    public static class ClassBExtensions
    {
        public double AFunction(this ClassB b)
        {
            bool condition = ...
            return condition ? b.GetMember1() : b.GetMember2();
        }
    }
