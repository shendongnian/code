    public class Method1
    {
        public static Method1 Method1FromAB(string a, string b)
        {
            return new Method1(a, b, "", "");
        }
        public static Method1 Method1FromCD(string c, string d)
        {
            return new Method1("", "", c, d);
        }
        private Method1(string a, string b, string c, string d)
        {
        }
    }
