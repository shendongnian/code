    using System;
    
    namespace Project
    {
        class MainClass
        {
            public static void Main (string[] args)
            {
                byte answer = 0;
                Console.WriteLine ("What is 27+4?");
                answer = byte.Parse(Console.ReadLine ());
                if (answer == 31) 
                {
                    bool answerCorrect = true;
                        if (answerCorrect == true)
                            Console.WriteLine ("Correct!");
                }
            }
        }
    }
