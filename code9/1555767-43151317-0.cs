    Enemy[] exclusionList = new Enemy[1]; //Construct outside of loop for efficiency
    for (int i = 0; i < spawnAmount; i++)
    {
        Enemy currentEnemy = enemies[i];
        exclusionList[0] = currentEnemy;
        if (enemies.Except(exclusionList).Any(e => e.collisionRect.Intersects(currentEnemy.collisionRect))
            enemies[i].allActive = false;
    }
