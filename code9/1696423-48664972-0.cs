    public static class ConsoleHelper
    {
        private static string[] input = new string[0];
        private static int inputIndex;
        public static void ReadNextInput()
        {
            input = Console.ReadLine().Split();
            inputIndex = 0;
        }
        public static int GetNextInt()
        {
            return int.Parse(ReadNextWord());
        }
        public static string GetNextWord()
        {
            return ReadNextWord();
        }
        private static string ReadNextWord()
        {
            if (inputIndex >= input.Length)
            {
                ReadNextInput();
            }
            return input[inputIndex++];
        }
    }
