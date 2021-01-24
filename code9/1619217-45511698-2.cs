    void Spawn()
    {
        if(GameObject.FindGameObjectsWithTag("Block").Length < 2){
            Instantiate(spawn, transform.position, Quaternion.identity);
        }
        spawnTime = Random.Range(1, 5);
        Invoke("Spawn", spawnTime);   
    } 
