    public static class ExtensionMethod
    {
        public static List<GameObject> findNearObjects(this GameObject targetObj, LayerMask layerMask, float distanceToSearch)
        {
            GameObject[] sceneObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
            List<GameObject> result = new List<GameObject>();
            for (int i = 0; i < sceneObjects.Length; i++)
                if (sceneObjects[i].layer == layerMask.value)
                    if (Vector3.Distance(sceneObjects[i].transform.position, targetObj.transform.position) < distanceToSearch)
                        result.Add(sceneObjects[i]);
            return result;
        }
    }
