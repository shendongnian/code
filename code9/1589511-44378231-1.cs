    using System;
    namespace ConsoleApp1
    {
        internal class LevelEnum : MyEnumeration
        {
            public static readonly LevelEnum Level1 = new LevelEnum(1, "Level 1", 2000, Program.Level1);
            public static readonly LevelEnum Level2 = new LevelEnum(2, "Level 2", 3000, Program.Level2);
            public static readonly LevelEnum Level3 = new LevelEnum(3, "Level 3", 4000, Program.Level3);
            public static readonly LevelEnum Level4 = new LevelEnum(4, "Level 4", 5000, Program.Level4);
            public static readonly LevelEnum Level5 = new LevelEnum(5, "Level 5", 6000, Program.Level5);
            public static readonly LevelEnum Level6 = new LevelEnum(6, "Level 6", 7000, Program.Level6);
            public static readonly LevelEnum Level7 = new LevelEnum(7, "Level 7", 8000, Program.Level7);
            public static readonly LevelEnum Level8 = new LevelEnum(8, "Level 8", 9000, Program.Level8);
            public LevelEnum()
            {
            }
            protected LevelEnum(int value, string displayName, int interval, Action action) : base(value, displayName, interval, action)
            {
            }
        }
    }
