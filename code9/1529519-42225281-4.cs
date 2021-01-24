     for(int i = 0; i < drones.Count; i++)
     {
         for(int j = 0; j < drones.Count; j++)
         {
             if (i == j)
                 continue;
             if (drones[i].SafeAreaContains(drones[j].Location))
                Debug.WriteLine($"{i} joined {j} safe area");
         }
     }
   
