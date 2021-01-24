        public static class ClassA
    {
        public static Type1 A { get; set; }
        public static Type2 B { get; set; }
        public static Type3 C { get; set; }
        public static Type4 D { get; set; }
        public static string Method(Type1 a, Type2 b, Type3 c, Type4 d)
        {
            a = a ?? default1;
            b = b ?? default2;
            c = c ?? default3;
            d = d ?? default4;
            //do smth
        }
        public static string Method(Type1 a, Type2 b, Type3 c)
        {
            return Method(a, b, c, D);
        }
        public static string Method(Type1 a, Type2 b, Type4 d)
        {
            return Method(a, b, C, d);
        }
        public static string Method(Type1 a, Type3 c, Type4 d)
        {
            return Method(a, B, c, d);
        }
        public static string Method(Type1 a, Type2 b)
        {
            return Method(a, b, C, D);
        }
        public static string Method(Type1 a, Type4 d)
        {
            return Method(a, B, C, d);
        }
        public static string Method(Type1 a, Type3 c)
        {
            return Method(a, B, c, D);
        }
        public static string Method(Type1 a)
        {
            return Method(a, B, C, D);
        }
    }
