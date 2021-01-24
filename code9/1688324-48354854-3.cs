    using System;
    namespace String{
    class Program
    {
        static void Main(string[] args)
        {
            string strA = "12456";
            string strB = "258";     
            Console.WriteLine(Foo(strA));
            Console.WriteLine(Foo(strB));
            Console.Read();
        }
         static char Foo(string str)
        {
            for(int i = 2; i < str.Length; i++)
                if(str[i].Equals('5')) return(str[i - 1]);
            return('x');
        }
    }
}
