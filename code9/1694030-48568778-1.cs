    void OnCollisionStay(Collision collisionInfo)
    {
        var cubeScript = collisionInfo.gameObject.GetComponent<CubeScriptTypeHere>();        
        var playerScript = collisionInfo.gameObject.GetComponent<PlayerScriptTypeHere>();
        
        if(cubeScript != null)
        {
            //This object hit a cube
            //Do something with cubeScript
        }
        if(playerScript != null)
        {
            //This object hit a player
           //Do something with playerScript
        }
    }
