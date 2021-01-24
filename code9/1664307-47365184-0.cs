    List<GameObject> findNearObjects(GameObject targetObj, LayerMask layerMask, float distanceToSearch)
    {
        //Get all the Object
        GameObject[] sceneObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
    
        List<GameObject> result = new List<GameObject>();
    
        for (int i = 0; i < sceneObjects.Length; i++)
        {
            //Check if it is this Layer
            if (sceneObjects[i].layer == layerMask.value)
            {
                //Check distance
                if (Vector3.Distance(sceneObjects[i].transform.position, targetObj.transform.position) < distanceToSearch)
                {
                    result.Add(sceneObjects[i]);
                }
            }
        }
        return result;
    }
