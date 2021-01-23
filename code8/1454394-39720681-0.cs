        void SpawnHorde()
        {
            int hordeCount = 200;
            float xPosition = 0;
    
            const int maxInColumn = 20;
    
            while (hordeCount > 0)
            {
                int numberInColumn = Random.Range(5, maxInColumn);
                hordeCount -= numberInColumn;
    
                if (hordeCount < 0)
                    numberInColumn += hordeCount;
    
                for (int i = 0; i < numberInColumn; i++)
                {
                    Vector3 spawnPosition = new Vector3(xPosition, 50, Random.Range(0, 100));
                    Instantiate(Resources.Load("Prefabs/Sphere"), spawnPosition, Quaternion.identity);
                }
    
                xPosition += (float)maxInColumn * 2f / (float)hordeCount;
            }
        }
