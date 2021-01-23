     string[] scores_temp = data.Split(' ');
        int[] scores = Array.ConvertAll(scores_temp, Int32.Parse);
      
        string[] alice_temp = data2.Split(' ');
        int[] aliceScore = Array.ConvertAll(alice_temp, Int32.Parse);
        var distinctScores = scores.Distinct().ToList();
            int rank = 0;
            int innerLoop = distinctScores.Count - 1;
            for (int j = 0; j <= aliceScore.Length-1; j++)
            {
                for (int i = innerLoop; i >= 0; i--)
                {
                    innerLoop = i;
                    if (aliceScore[j] >= distinctScores[i])
                    {
                        rank = i;
                    }
                   
                    else if (aliceScore[j] < distinctScores[i])
                    {
                        rank = i;
                        rank += 2;
                        break;
                    }
                }
                if (rank.ToString() == "0") { Console.WriteLine(rank.ToString().Replace("0", "1")); } else { Console.WriteLine(rank); };
            }
            Console.ReadLine();
          
        }
