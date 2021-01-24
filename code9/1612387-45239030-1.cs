	int nBirdsSpawned = 0;
	private List<int> spawnedBrids = new List<int>();
    //Before this you only get bird id and do not spawn
	private void CheckForBirdSpawn()
	{
		if(nBirdsSpawned <= 5)
		{
			if(!spawnedBrids.Contains(birdYouWantToSpawnID))
			{
				spawnedBrids.Add(birdYouWantToSpawnID);
                //here you do spawning
			}
			else
			{
				//Start random id pick again
			}
		}
		else
		{
			if(!spawnedBrids.Contains(birdYouWantToSpawnID))
			{
			//With this we will shift all items from spawnedBirds by 1 place backward
			List<int> tmp = new List<int>();
			tmp.Add(spawnedBrids[1]);//this is second item in old list and first in current
			tmp.Add(spawnedBrids[2]);
			tmp.Add(spawnedBrids[3]);
			tmp.Add(spawnedBrids[4]);
			spawnedBrids = tmp;
			
				spawnedBrids.Add(birdYouWantToSpawnID);
                //here you do spawning
			}
			else
			{
				//Start random id pick again
			}
		}
	}
