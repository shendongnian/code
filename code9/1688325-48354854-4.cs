    using System;
    namespace String{
    class Program
    {
        static void Main(string[] args)
        {
            string strA = "12456";
            string strB = "258";
            string strC = "53452";
            string strD = "12346";
            Console.WriteLine(Foo(strA));
            Console.WriteLine(Foo(strB));
            Console.WriteLine(Foo(strC));
            Console.WriteLine(Foo(strD));
            Console.Read();
        }
       static char Foo(string str)
        {
            if (str[0].Equals('5'))return 'x';
            for (int i = 1; i < str.Length; i++)
                if (str[i].Equals('5')) return(str[i - 1]);
            return 'x';
        }
    }
}
