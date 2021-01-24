    using System;
    using static System.Console;
    
    namespace ConsoleApp3 {
        class Program {
            static void Main(string[] args) {
                // prompt user to ask how many test scores to build the size of the array
                Write("How many test scores total: ");
                string testCountStr = ReadLine();
                int testCount = Convert.ToInt32(testCountStr );
                int[] testScores = new int[testCount];
    
                // create the loop of asking the test scores limited to the array sSize
                for (int i = 0; i < testCount; i++) {
                    Write($"Please enter score for test {i + 1} from 0 to 100: ");
                    string scoreStr = ReadLine();
                    int score = Convert.ToInt32(scoreStr);
                    if (score > 100 || score < 0) {
                        //TODO: handle your error
                        WriteLine("Invalid score. Please try again");
                        --i;
                        continue;
                    }
                    testScores[i] = score;
                }
    
                WriteLine();
                // create loop to display all test scores
                for (int i = 0; i < testScores.Length; ++i)
                    WriteLine($"Your score for test {i + 1} is {testScores[i]}");
    
    
            }
        }
    }
