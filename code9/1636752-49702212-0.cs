    for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    int resultat = i * j;
                    Console.Write(resultat.ToString().PadLeft(4));
                }
                Console.WriteLine();
            }
