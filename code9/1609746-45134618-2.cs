    public void CreateActualEnemies()
        {
            int r;
            int potEnemyNum = potentialEnemies.Count;         
            int numEnemies;
            Random rand = new Random();
            numEnemies = rand.Next(1, 4 );
            for (int i = 0; i < numEnemies; i++)
            {
                r = rand.Next(0,potEnemyNum);
                Enemy ene = new Enemy();
                ene = potentialEnemies.ElementAt(r);
                actualEnemies.Add(ene);
            }
            DisplayEnemyDetails();
        }
