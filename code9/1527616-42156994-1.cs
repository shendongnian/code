            string code;
            int intCode;
            int cd = 0, dvd = 0, video = 0, book = 0;
            bool isCorrectInput = false;
            while (!isCorrectInput)
            {
                isCorrectInput = true;
                Console.Write("Enter code: ");
                code = Console.ReadLine();
                if (code.Length == 1)
                {
                    intCode= Convert.ToInt32(code);
                    // intCode  /= 100000;
                    switch (intCode)
                    {
                        case 1:
                            cd++;
                            break;
                        case 2:
                            dvd++;
                            break;
                        case 3:
                            video++;
                            break;
                        case 4:
                            book++;
                            break;
                        default:
                            isCorrectInput = false;
                            break;
                    }
                }
                else
                {
                    isCorrectInput = false;
                }
                if (!isCorrectInput)
                    Console.Write("INVALID CODE ENTERED!");
            }
