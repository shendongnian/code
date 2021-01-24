    public void StartSpawn()
    {
        StartCoroutine(Spawn(columnPos1));
        StartCoroutine(Spawn(columnPos2));
        StartCoroutine(Spawn(columnPos3));
        StartCoroutine(Spawn(columnPos4));
    }
    
    IEnumerator Spawn(float columnPos)
    {
        yield return new WaitForSeconds(1.5f);
        time = GameController.instance.time;
        while (true)
        {
              // Random select from prefabs
              GameObject geometryObject = spawnObjects[Random.Range(0, spawnObjects.Length)];
              // X is middle of random picked columns
              float x = columnPos;
              Vector3 spawnPosition = new Vector3(x, transform.position.y, 0.0f);
              Quaternion spawnRotation = Quaternion.identity;
    
              // Random object in row, will be spawned in one column
              int rnd = Random.Range(1, 6);
    
              // Spawn random count game object in one row
              for (int i = 0; i < rnd; i++)
              {                  
                  GameObject temp = Instantiate(geometryObject, spawnPosition, spawnRotation);
    
                  // Get Sprite render
                  SpriteRenderer sr = temp.GetComponent<SpriteRenderer>();
    
                  // Change color of game object
                  sr.color = colors[Random.Range(0, colors.Length)];
    
                  // Get script for falling down
                  FallingDown fl = temp.GetComponent<FallingDown>();
                  // Increase fall
                  fl.fallSpeed += 0.1f;
                  // Wait between spawns
                  yield return new WaitForSeconds(Random.Range(0.35f, 1.0f));
              }
              yield return new WaitForSeconds(1.0f);
    }
