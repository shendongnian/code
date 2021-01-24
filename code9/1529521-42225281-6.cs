     for(int i = 0; i < drones.Count - 1; i++)
     {
         for(int j = i + 1; j < drones.Count; j++)
         {
             if (drones[i].SafeAreaContains(drones[j].Location))
                Debug.WriteLine($"{i} joined {j} safe area");
         }
     }
