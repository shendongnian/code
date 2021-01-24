    class Animal
    {
        public static int LegCount { get { return 0; } }
    }
    class Snake : Animal
    {
        public static new int LegCount { get { return 0; } }
    }
    
    class Human : Animal
    {
        public static new int LegCount { get { return 2; } }
    }
    class Cat : Animal
    {
        public static new int LegCount { get { return 4; } }
    }
