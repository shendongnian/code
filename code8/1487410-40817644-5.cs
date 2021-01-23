    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace CalculatingGame
    {
        abstract class GameType
        {
            public int Answer;
            public Random Rnd = new Random();
    
            public abstract string MakeSum(Difficulty Diff);
        }
    
        class GameAdditive : GameType
        {
            public override string MakeSum(Difficulty Diff)
            {
                int num1 = Rnd.Next(Diff.MinNumber, Diff.MaxNumber);
                int num2 = Rnd.Next(Diff.MinNumber, Diff.MaxNumber);
    
                Answer = num1 + num2;
    
                return num1 + " + " + num2;
            }
        }
    
        class GameSubtractive : GameType
        {
            public override string MakeSum(Difficulty Diff)
            {
                int num1 = Rnd.Next(Diff.MinNumber, Diff.MaxNumber) + Diff.MaxNumber;
                int num2 = Rnd.Next(Diff.MinNumber, Diff.MaxNumber);
    
                Answer = num1 - num2;
    
                return num1 + " - " + num2;
            }
        }
    
        class GameRandomize : GameType
        {
            public override string MakeSum(Difficulty Diff)
            {
                int mode = Rnd.Next(0, 2);
    
                if (mode == 0)
                {
                    int num1 = Rnd.Next(Diff.MinNumber, Diff.MaxNumber);
                    int num2 = Rnd.Next(Diff.MinNumber, Diff.MaxNumber);
                    Answer = num1 + num2;
    
                    return num1 + " + " + num2;
                }
                else
                {
                    int num1 = Rnd.Next(Diff.MinNumber, Diff.MaxNumber) + Diff.MaxNumber;
                    int num2 = Rnd.Next(Diff.MinNumber, Diff.MaxNumber);
                    Answer = num1 - num2;
    
                    return num1 + " - " + num2;
                }
            }
        }
    }
