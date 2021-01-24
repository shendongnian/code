    class Program
    {
        static string[,] GAArr; // define in the class, but outside of the functions
        // ...
        static void World()
        {
            // ...
            GAArr = new string[GAWidth, GAHeight]; // create
            // ...
        }
        // ...
    }
    class Wall
    {
        void Draw()
        {
            Program.GAArr[x,y] ? "#"; // Use in another class
        }
    }
