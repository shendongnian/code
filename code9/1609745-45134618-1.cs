    public void CreateActualEnemies()
        {
            Random rand = new Random();
            int numEnemies = rand.Next(1, 4 );
            for (int i = 0; i < numEnemies; i++)
            {
                Enemy ene = new Enemy();
                ene.characterName = "" + ene.GetType().Name + " " + i; // or something similar to give the ene a unique name.
                actualEnemies.Add(ene);
            }
            DisplayEnemyDetails();
        }
