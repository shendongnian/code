    for (int i = 0; i < spawnAmount - 1; i++)
    {
       for (int j = i + 1; j < spawnAmount; j++)
       {
           if (enemies[i].collisionRect.Intersects(enemies[j].collisionRect))
           {
               enemies[i].allActive = false;
           }
       }
    }
