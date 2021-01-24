            string[] code = new string[9];
            int[] intCode = new int[9];
            int cd = 0, dvd = 0, video = 0, book = 0;
            for (int i = 0; i < 10; i++)
            {
                bool isCorrectInput = false;
                while (!isCorrectInput)
                {
                    isCorrectInput = true;
                    Console.Write("Enter code#{0}: ", i + 1);
                    code[i] = Console.ReadLine();
                    if (code[i].Length == 5)
                    {
                        intCode[i] = Convert.ToInt32(code[i]);
                        intCode[i] /= 100000;
                        switch (intCode[i])
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
                    if(!isCorrectInput)
                        Console.Write("INVALID CODE ENTERED!");
                }
            }
