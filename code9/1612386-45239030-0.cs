	int nBirdsSpawned = 0;
	private List<int> spawnedBrids = new List<int>();
	private void CheckForBirdSpawn()
	{
		if(nBirdsSpawned <= 5)
		{
			if(!spawnedBrids.Contains(birdYouWantToSpawnID))
			{
				spawnedBrids.Add(birdYouWantToSpawnID);
			}
			else
			{
				//Start random spawning again
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
			}
			else
			{
				//Start random spawning again
			}
		}
	}
