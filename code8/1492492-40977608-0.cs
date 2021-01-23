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
            if (obj.KeyCode == KeyCode.Space)
            {
                HandleComparison(builder.ToString());
                builder.Clear();
                return;
            }
            builder.Append(obj);
        }
        private static void HandleComparison(string compareString)
        {
            Console.WriteLine(compareString);
        }
    }
