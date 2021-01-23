        GameObject[] tempObj = GameObject.FindGameObjectsWithTag("Untagged") as GameObject[];
        MeshCollider[] allMeshes = new MeshCollider[tempObj.Length];
        for (int i = 0; i < allMeshes.Length; i++)
        {
            allMeshes[i] = tempObj[i].GetComponent<MeshCollider>();
            if (allMeshes[i] != null)
            {
                allMeshes[i].enabled = false; //Optional
                Destroy(allMeshes[i]);
            }
        }
