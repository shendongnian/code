     currentSpawnLocation = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
     if (System.Array.IndexOf(lastSpawns, currentSpawnLocation) == -1)
     {
         // the currentSpawnlocation is not found
         GameObject cubeClone = (GameObject)Instantiate(Cubes[Random.Range(0,Cubes.Length)], transform.position + currentSpawnLocation, Quaternion.identity);
         cubeClone.transform.parent = CubeClones;
         // I assume you want to store currentSpawnLocation in the array
         // for that I use your cubeSpawns variable to keep track of where 
         // we are in the array. If you use cubeSpawns for something else, adapt accordingly
         lastSpawns[cubeSpawns] = currentSpawnLocation;
         cubeSpawns = cubeSpawns + 1;
         // prevent going beyond the capacity of the array
         // you might want to move this in front of the array assingment
         if (cubeSpawns > lastSpawns.Length)   
         {
            // doing this will overwrite earlier Vector3
            // in your array
            cubeSpawns = 0;
         }
     }
