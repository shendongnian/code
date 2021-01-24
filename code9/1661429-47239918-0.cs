    using System;
    namespace ConsoleApp
    {
        class Program
        {
            static void Main (string[] args)
            {
                var random = new Random ();
                var array = new int[10];
                for (int i = 0; i < array.Length; i++)
                {
                    bool isOdd = (i % 2) == 1; // check remainder
                    int randomNumber = random.Next (0, 11); // 0..10
                    if (isOdd) randomNumber = -randomNumber; // change sign
                    array[i] = randomNumber;
                }
            }
        }
    }
