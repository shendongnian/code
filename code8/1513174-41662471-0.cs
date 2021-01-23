     private static void LosujPytania()
                {         
   
            Random losowa = new Random();
            List<int> pula = new List<int>();
                    int a = losowa.Next(1,20);
                    while (pula.Count < 10)
                    {
                        //Your code is not really checking for duplicates so I replace it with boolean condition below
                        //foreach (int i in pula)
                        //{
                        //    if (a == i)
                        //    {
                        //        a = losowa.Next(1, 20);
                        //        break;
                        //    }
                       
                        //}
                        a = losowa.Next(1, 20);
                        //This will check if your list doesn't contain your numbers yet before adding to make sure everything is unique
                        if (!pula.Contains(a))
                        pula.Add(a);
                    }
            }
