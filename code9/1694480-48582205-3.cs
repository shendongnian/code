    // EVIL CODE: DO NOT USE
    using System;
    
    public class Test
    {
        static void Main(string[] args)
        {
            if (!string.IsNullOrEmpty(Call(FuncGetStr, out string result)))
            {
                Console.WriteLine(result);
            }
        }
        
        static string FuncGetStr() => "foo";
        
        static T Call<T>(Func<T> func, out T x) => x = func();
    }
