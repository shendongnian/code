    int randomIndex;   
     
    void SpawnArrow()
        {
            //some code here        
            randomIndex = UnityEngine.Random.Range(0, arrows.Length); 
            GameObject prefab = arrows[randomIndex];
            GameObject clone = Instantiate(prefab, new Vector3(0.02F, 2.18F, -1), 
            Quaternion.identity);
        }
        
        void Update()
        {
           if (randomIndex == 1 && (Input.GetButtonDown("a") == true))
           {
               ScoreManager.score += scoreValue;
           }
           //and so on
        
        }
