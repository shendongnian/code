    for (int i = 0; i < question.Count; i++)
    {
        if (question[i] == Console.ReadLine())
        {
            Console.Clear();
            switch (i)
            {
                case 0:
                                
                    randIndex = rand.Next(0, 3);
                    Console.WriteLine(state[randIndex]);
                                
                    break;
    
                case 1:
                    randIndex = rand.Next(0, 4);
                    Console.WriteLine(joke[randIndex]);
                    break;
    
                case 2:
                    randIndex = rand.Next(0, 2);
                    Console.WriteLine(yourName[randIndex]);
                    break;
            }
            Discussion();
        }
                    
    }
