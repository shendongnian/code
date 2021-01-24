    int ans1 = getRand();
    int ans2 = getRand();
    int ans3 = getRand();
    public int getRand()
    {
     done = false;
     while(!done)
     {
         tempAns  = rand.Next(0, 2);
         done = false;
         foreach(int i in answersDone)
         {
             if (tempAns == i)
             {
                 done = true;
             }
         }
     }
        answersDone.Add(tempAns);
        return tempAns;
    }
    }
