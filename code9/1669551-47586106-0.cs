    using System;
    namespace TestProgram {
        class Test {
            static void Main() {
                int number = 10;
                //MultiplyByTen(number);
                //Console.WriteLine(number);
                Console.WriteLine(MultiplyByTen(number));
                Console.ReadKey(true);
            }
            static public int MultiplyByTen(int num) {
                return num *= 10;
            }
        }
    }
