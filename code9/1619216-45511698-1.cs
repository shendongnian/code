    void Spawn()
    {
        if(GameObject.FindGameObjectsWithTag("Block").Length < 2){
            spawnTime = Random.Range(1, 5);
            Instantiate(spawn, transform.position, Quaternion.identity);
            Invoke("Spawn", spawnTime);
        }   
    } 
