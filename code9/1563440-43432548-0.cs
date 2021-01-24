        bool hasSpawnedPylon = false;
        void FixedUpdate()
        {
            int currPosition = (int)transform.position.z;
            if (currPosition % spawnDistance == 0f)
            {
				if (!hasSpawnedPylon)
				{
					SpawnCoinPylon();
                    SpawnNormalPylon();
				}
            }
			else
			{
                hasSpawnedPylon = false;
            }
		}
