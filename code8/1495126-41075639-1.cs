    string bits = "";//consists of many C's and N's each for one collectible
    for(int i=0; i<collectiblesCount; i++) 
        bits += collectibleGroup1[i].isCollected ? "C" : "N";
    //store
    PlayerPrefs.SetKey("collectibles", bits);
    //fetch
    bits = PlayerPrefs.GetKey("collectibles", "");
    for(int i=0; i<collectiblesCount; i++) 
        if(i < bits.Length)
            collectible[i].isCollected = bits[i] == "C";
        else
            collectible[i].isCollected = false;
