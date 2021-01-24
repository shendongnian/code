    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            while (true)
            {
                counter++;
                DrawScreen(counter); 
                Console.ReadKey();
            }
        }
        static void DrawScreen(int turn)
        {
            // Clear Console
            Console.Clear();
            // Draw Statusbar again on the 'top'
            Console.WriteLine("Current Turn: {0}", turn);
            
            // Draw additional stuff
        }
    }
