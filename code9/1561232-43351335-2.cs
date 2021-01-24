    public GameObject SpawnArrow(<some params>){
    	GameObject prefab = arrows[UnityEngine.Random.Range(0, arrows.Length)];
    	while(interval > 0){
    		if(interval = 0){
    			prefab = arrows[UnityEngine.Random.Range(0, arrows.Length)];
    			GameObject clone = Instantiate(prefab, new Vector3(0.02F, 2.18F, -1), Quaternion.identity);
    		} else {
                System.Threading.Thread.sleep(1000) // wait for the second.
    			interval = interval - 1;
    		}
    	}
    	return prefab;
    }
