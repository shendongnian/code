    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication16
    {
        public abstract class ICTcampus
        {
            public int addNumbers(int number1, int number2)
            {
                return number1 + number2;
            }
    
            public abstract int multiplyNumbers(int number1, int number2);
            
        }
        public class Derivedclass : ICTcampus
        {
            public override int multiplyNumbers(int number1, int number2)
            {
                return number1 * number2;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
    
                Derivedclass obj = new Derivedclass();
                int add = obj.addNumbers(2, 3);
                Console.Write(" addition is :{0}", add);
                // Console.Write(" multiplication is :{0}", obj.multiplyNumbers(2, 3));
    
            }
        }
    
    }
