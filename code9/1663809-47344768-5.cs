    public GameObject[] buildings;
    public int mapWidth = 20;
    public int mapHeight = 20;
    int buildingFootprint = 45;
    bool scaleUniform = true;
    
    
    // Procedural Generation
    void Start ()
    {
        float seed = Random.Range(0, 500);
        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                int result = (int)(Mathf.PerlinNoise(w/3.0f + seed, h/3.0f + seed) * 50);
                float randomY = Random.Range(-360f, 360f); // get random rotation for Y axis
                
                Vector3 pos = new Vector3(w * buildingFootprint, 10, h * buildingFootprint);
                Vector3 rot = new Vector3(0, randomY, 0); // set the random Y rotation to a new Vector3
                Vector3 scale = Vector3.one; // create a new Vector3 for scale
                
                if(scaleUniform) // scale the object uniformly
                {
                    float randomScale = Random.Range(min, max);
    
                    scale = new Vector3(randomScale, randomScale, randomScale);
                }
                else // or scale it randomly on every axis
                {
                    scale = new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
                }
                
                int index = 0; // declare index here so you dont repeat yourself in ifs
    
                if (result < 5) // now you only set index value instead of copying and pasting long code in each if else
                    index = 0;
                else if (result < 10)
                    index = 5;
                else if (result < 15)
                    index = 6;
                else if (result < 20)
                    index = 1;
                else if (result < 30)
                    index = 2;
                else if (result < 40)
                    index = 3;
                else if (result < 50)
                    index = 4;
                    
                GameObject spawnedBuilding = Instantiate(buildings[index], pos, Quaternion.Euler(rot)); // and finally instantiate the object
                spawnedBuilding.transform.localScale = scale; // and set its rotation
            }
        }
    
    }
