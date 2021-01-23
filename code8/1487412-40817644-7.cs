    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace CalculatingGame
    {
        // nice thing about abstract classes and child classes are that you can store a 'EasyDifficulty' object under variable-type 'Difficulty'
        // this allows me to create a dictionary, with 'Difficulty' type as value, and yet put all the different child classes in there
        // another thing you can do, and you can see it under 'Operators.cs' file, is that you can have a method, with the same name in every
        // child class, and yet they perform different things.
        abstract class Difficulty
        {
            public int MinNumber = 1;
            public int MaxNumber = 1;
            // Time in ticks. 1 tick = 100ms. Reason why I made it so is because maybe you want to give the player 7.5 seconds to do the sum
            public int Time = 100;
        }
    
        class EasyDifficulty : Difficulty
        {
            public EasyDifficulty()
            {
                MinNumber = 1;
                MaxNumber = 9;
                Time = 100;
            }
        }
    
        class MediumDifficulty : Difficulty
        {
            public MediumDifficulty()
            {
                MinNumber = 1;
                MaxNumber = 99;
                Time = 75;
            }
        }
    
        class HardDifficulty : Difficulty
        {
            public HardDifficulty()
            {
                MinNumber = 1;
                MaxNumber = 999;
                Time = 50;
            }
        }
    }
