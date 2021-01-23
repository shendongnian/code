    void updateGameObjectsMatchingPosition(float x, float y, float z)
    {
        // Please try to use something more specific like GameObject.FindGameObjectWithTag("CoolTag");
        var gameObjects : GameObject[] = GameObject .FindObjectsOfType(GameObject) as GameObject[];
      
        for(var i = 0; i < gameObjects.length; i++) {
           var position = gameObjects[i].transform.position;
           if(position.x == x && position.y == y && position.z == z) {
               //Do something with the position of this object.
               gameObjects[i].transform.position = new Vector3(x + 1, y + 1, z + 1);
           }
        }
    }
