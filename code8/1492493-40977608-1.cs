	class Program
    {
        private static StringBuilder builder;
        static void Main(string[] args)
        {
            using (var api = new KeystrokeAPI())
            {
                builder = new StringBuilder();
                api.CreateKeyboardHook(HandleKeyPress);
                Application.Run();
            }
        }
        private static void HandleKeyPress(KeyPressed obj)
        {
            // To be more reliable, lets use the KeyCode enum instead
            if (obj.KeyCode == KeyCode.Space)
            {
                // Spacebar was pressed, let's check the word and flush the StringBuilder
                HandleComparison(builder.ToString());
                builder.Clear();
                return;
            }
            // Space wasn't pressed, let's add the word to the StringBuilder
            builder.Append(obj);
        }
        // Handle comparison logic here, I.E check word if exists on blacklist
        private static void HandleComparison(string compareString)
        {
            Console.WriteLine(compareString);
        }
    }
