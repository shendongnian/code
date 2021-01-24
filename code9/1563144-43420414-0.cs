    public GameObject obj1;
    public GameObject obj2;
    
    void Update()
    {
        UnityEngine.Debug.Log(getSqrDistance(obj1.transform.position, obj2.transform.position));
    }
    
    public float getSqrDistance(Vector3 v1, Vector3 v2)
    {
        return (v1 - v2).sqrMagnitude;
    }
