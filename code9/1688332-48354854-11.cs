    using System;
    namespace String{
    class Program
    {
        static void Main(string[] args)
        {
            bar('5',"12456","258");
            Console.Read();
        }
        static void bar(char c, string strA, string strB)
        {
            if (Foo(c,strA)!= 'x' && Foo(c,strB)!= 'x')
                Console.WriteLine("{0} {1}", Foo(c,strA), Foo(c,strB)); 
            else  Console.WriteLine("no match"); 
        }
       static char Foo(char c, string str)
        {
            if (str[0].Equals(c)) return 'x';
            for (int i = 1; i < str.Length; i++)
                if (str[i].Equals(c)) return(str[i - 1]);
            return 'x';
        }
    }
}
