    using System;
    namespace String{
    class Program
    {
        static void Main(string[] args)
        {
            string strA = "12456", strB = "258",
                   strC = "53452", strD = "12346";
            bar(strA, strB);
            bar(strA, strC);
            bar(strB, strD);
            Console.Read();
        }
        static void bar(string strA, string strB)
        {
            if (Foo(strA)!= 'x' && Foo(strB) != 'x')
                Console.WriteLine("{0} {1}", Foo(strA), Foo(strB)); 
            else  Console.WriteLine("no match"); 
        }
       static char Foo(string str)
        {
            if (str[0].Equals('5')) return 'x';
            for (int i = 1; i < str.Length; i++)
                if (str[i].Equals('5')) return(str[i - 1]);
            return 'x';
        }
    }
}
