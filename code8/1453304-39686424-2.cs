    void quicksort(List<Enemy> enemies, int first, int last)
    {
       int left = first;
       int right = last;
       int pivot = first;
       first++;
       while (last >= first)
       {
           if(enemies[first].Aggro >= enemies[pivot].Aggro &&
               enemies[last].Aggro < enemies[pivot].Aggro)
               swapp(enemies, first, last)
           else if(enemies[first].Aggro >= enemies[pivot].Aggro)
             last--;
           else if(enemies[last].Aggro < colliders[pivot].Aggro)
             first++;
           else
           {
                last--;
                first++;
           }
       }
       swap(enemies, pivot, last);
       pivot = last;
       if(pivot > left)
          quicksort(enemies, left, pivot);
       if(right > pivot + 1)
         quicksort(enemies, pivot + 1, right);
    }
    void swap(List<Enemy> enemies, int left, right)
    {
       var temp = enemies[right];
       enemies[right] = enemies[left];
       enemies[left] = temp;
    }
    void CheckAggro()
    {
       quicksort(enemies, 0, enemies.Count - 1);
       for(int = 0; i < players.Count; i++)
       {
           for(int j = 0 < enemies.Count; j++)
           {
               if(players[i].AggroThreshhold < enemies[j].Aggro)
               {
                    break;
               }
               // Perform what happens when enemy is high on aggro threshold.
           }
       }
    }
