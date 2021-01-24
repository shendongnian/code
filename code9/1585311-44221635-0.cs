    static void Main(string[] args)
        {
            String username;
            String password;
            int row;
            string[,] accnts = { { "jack", "111", "1" }, { "ibo", "121", "2" } };
            Console.Write("enter username >> ");
            username = Console.ReadLine();
            Console.Write("enter password >> ");
            password = Console.ReadLine();
            for (row = 0; row < 3; row++)
            {
                if (username.Equals(accnts[row, 0]) && password.Equals(accnts[row, 1]))
                {
                    Console.WriteLine("welcome " + accnts[row, 0]);
                }
                else if (username.Equals(accnts[row, 0]) && password.Equals(accnts[row, 1]))
                {
                    Console.WriteLine("welcome " + accnts[row + 1, 0]);
                }
                else
                {
                    Console.WriteLine("invalid access");
                    // changed break to continue, because it was crashing
                    continue;
                }
                string[,] question_id = { { "1", "1" }, { "1", "2" }, { "2", "3" }, { "2", "4" } };
                string[,] questions = { { "Türkiyenin baskenti neresidir?", "1" }, { "Baskomutan kim?", "2" }, { "2 kere 2?", "3" }, { "when did the world war 1 start?", "4" } };
                string[,] Answers = { { "a)ankara b)istanbul c)izmir", "1" }, { "a)ismet b)Atatürk c)Ali ", "2" }, { " a)1 b)2 c)4 ", "3" }, { " a)1912 b)1914 c)1915", "4" } };
                string[,] trueAnswers = { { "a", "1" }, { "b", "2" }, { "c", "3" }, { "c", "4" } };
                int result = 0;
                string answers = "";
                // here I've added a start and end thingy to offset the loop acording to logged user.
                int start = 0;
                int endModifier = 2;
                if (username == accnts[1,0])
                {
                    start = 2;
                    endModifier = 0;
                }
                for (int i = start; i < questions.GetLength(0) - endModifier; i++)
                {
                    Console.WriteLine(questions[i, 0]);
                    Console.WriteLine("--------------------------");
                    for (int y = 0; y < Answers.GetLength(0); y++)
                    {
                        if (Answers[y, 1] == questions[i, 1])
                        {
                            Console.WriteLine(Answers[y, 0]);
                            answers = Console.ReadLine();
                            for (int z = 0; z < trueAnswers.GetLength(0); z++)
                            {
                                if (trueAnswers[z, 1] == questions[i, 1])
                                {
                                    if (trueAnswers[z, 0] == answers)
                                        result = result + 10;
                                    Console.WriteLine("total is  " + result);
                                }
                            }
                        }
                    }
                }
                if (result < 20)
                {
                    Console.WriteLine("failed");
                }
                else
                {
                    Console.WriteLine("congrats");
                }
                return;
            }
        }
