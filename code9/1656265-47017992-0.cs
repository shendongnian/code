    void Update () 
	{    
		while (playerTransform.position.z - safeZone > (spawnZ - amtOfTilesOnScreen * tileLength))
		{
			// we need to add a new tile in front of the player
			GameObject t;
			if (deactivatedTiles.Count == 0) {
				// no deactivated tiles so we need to instantiate a new tile
				t = SpawnTileAtFront ();
			} else {
				// otherwise take deactivated tile into use
				t = GetRandomDeactivatedTile ();
				MoveTileToTheFront (t);
			}
			// new tile is now active tile
			activeTiles.Add (t);
			// take oldest active tile and move it to deactivated list
			DisposeActiveTiles(0);
		}
	}
