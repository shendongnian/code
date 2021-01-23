        static void Main(string[] args)
        {
            string[] answerHolder = { "", "", "" }; //MY originaly code has 13, but I am doing 3 to write it out faster
            string[] prompt = { "noun", "verb", "adjective" };
            Console.WriteLine("Help me finish the story:");
            Console.WriteLine("A <noun> likes to eat a lot. It likes to <verb> in the <adjective> looking water. ");
            //then it will ask the user to enter a noun, verb, and adjective
            for (int i = 0; i < answerHolder.Length; i++)
            {
                Console.Write("Please enter a/an " + prompt[i] + ": ");
                answerHolder[i] = Console.ReadLine();
            }
            //Console.WriteLine("A {0} likes to eat a lot. It likes to {1} in the {2} looking water.", answerHolder[0], answerHolder[1], answerHolder[2]);
            WriteFormattedLine("A {0} likes to eat a lot. It likes to {1} in the {2} looking water.", answerHolder);
            Console.ReadLine();
        }
        private static void WriteFormattedLine(string format, params string[] answers)
        {
            int formatLength = format.Length;
            int currIndex = 0;
            bool readingNumber = false;
            string numberRead = string.Empty;
            while (currIndex < formatLength)
            {
                var ch = format[currIndex];
                switch (ch)
                {
                    case '{':
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        readingNumber = true;
                        numberRead = string.Empty;
                        break;
                    case '}':
                        var number = int.Parse(numberRead);
                        var answer = answers[number];
                        Console.Write(answer);
                        Console.ResetColor();
                        readingNumber = false;
                        break;
                    default:
                        if (readingNumber)
                            numberRead += ch;
                        else
                            Console.Write(ch);
                        break;
                }
                currIndex++;
            }
        }
