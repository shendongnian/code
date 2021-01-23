    GameObject[] players;
    void test()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject go in players)
        {
            Debug.Log("Player " + go + " is named " + go.name);
        }
    }
    GameObject getGameObject(string gameObjectName)
    {
        for (int i = 0; i < players.Length; i++)
        {
            //Return GameObject if the name Matches
            if (players[i].name == gameObjectName)
            {
                return players[i];
            }
        }
        Debug.Log("No GameObject with the name \"" + gameObjectName + "\" found in the array");
        //No Match found, return null
        return null;
    }
