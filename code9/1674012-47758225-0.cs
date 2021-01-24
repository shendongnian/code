                Please check below code.
                List<int> sumList = new List<int>();
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("Anna kokonaisluku: ");
                    String Luku = Console.ReadLine();
                    int annettu = int.Parse(Luku);
                    sumList.Add(annettu);
                }
                int result = sumList.Sum();
