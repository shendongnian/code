    public static class Extensions
    {
        public A ToA(this B b)
        {
            return new A() 
            {
                p1 = b_obj.p1,
                p3 = b_obj.p3,
            };
        }
    }
