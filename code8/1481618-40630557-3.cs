        static void printQn()
        {
            Questions mcq = new Questions();
            Random r = new Random();
            //Randomize question indexes and grab first
            int[] questions = Enumerable.Range(0, mcq.questions.Length).OrderBy(q => r.Next()).ToArray();
            int question = questions.First();
            
            //Print first question
            Console.WriteLine(mcq.questions[question]);
            Wait(2);
            //Randomize option indexes (GetLength(1) will return the size of the 'y' dimension of the options array, so 4)
            int[] options = Enumerable.Range(0, mcq.options.GetLength(1)).OrderBy(o => r.Next()).ToArray(); 
            //prints options
            int optionCount = 1;
            foreach (int option in options)
            {
                Console.WriteLine("[{0}] {1}", optionCount, mcq.options[question, option]);
                Wait(1);
                optionCount++;
            }
        }
