    enum Sign // ASCII codes
    {
        Mod = 37, // '%'
        Mul = 42, // '*'
        Add = 43, // '+'
        Sub = 45, // '-'
        Div = 47  // '/'
    }
    static class SignExtension
    {
        public static Char ToChar(this Sign s)
        {
            return (s as IConvertible).ToChar(null);
        }
    }
    class MainClass
    {
        static void Main(String[] args)
        {
            Sign op = Sign.Add;
            Char c    = op.ToChar();   // c == '+'
            String s1 = op.ToString(); // s1 == "Add"
            String s2 = c.ToString();  // s2 == "+"
        }
    }
