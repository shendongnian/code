    void LargeBeamPlayerGenerator(){
    List<GameObject> tempObj = LargeBeamObject;
        for (int i = 0; i < 2; i++){
            int randomGameObject = Random.Range(0,4-i);
            GameObject selectedGameObject = tempObj[randomGameObject];
            MeshRenderer visible = selectedGameObject.GetComponent<MeshRenderer>();
            visible.enabled = true;
            tempObj.RemoveAt(randomGameObject);
        }
    }
