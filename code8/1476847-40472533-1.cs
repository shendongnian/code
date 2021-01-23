    static void Main(string[] args)
        {
            string[] Name = File.ReadAllLines("M:\\StackOverflowQuestionsAndAnswers\\40472088\\data.txt", Encoding.Default);
            for (int i = 0; i < Name.Length; i++)
            {
                Console.WriteLine(Name[i]);
            }
            Console.ReadLine();
        }
