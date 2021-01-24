    public GameObject obj1;
    public GameObject obj2;
    
    const float MAX_DISTANCE = 200;
    
    Renderer mRenderer;
    
    void Start()
    {
        mRenderer = GetComponent<Renderer>();
    
        //ENABLE FADE Mode on the material if not done already
        mRenderer.material.SetFloat("_Mode", 2);
        mRenderer.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mRenderer.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mRenderer.material.SetInt("_ZWrite", 0);
        mRenderer.material.DisableKeyword("_ALPHATEST_ON");
        mRenderer.material.EnableKeyword("_ALPHABLEND_ON");
        mRenderer.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        mRenderer.material.renderQueue = 3000;
    }
    
    
    void Update()
    {
        //Get distance between those two Objects
        float distanceApart = getSqrDistance(obj1.transform.position, obj2.transform.position);
        UnityEngine.Debug.Log(getSqrDistance(obj1.transform.position, obj2.transform.position));
    
        //Convert 0 and 200 distance range to 0f and 1f range
        float lerp = mapValue(distanceApart, 0, MAX_DISTANCE, 0f, 1f);
    
        //Lerp Alpha between near and far color
        Color lerpColor = mRenderer.material.color;
        lerpColor.a = Mathf.Lerp(1, 0, lerp);
    
        mRenderer.material.color = lerpColor;
    }
    
    public float getSqrDistance(Vector3 v1, Vector3 v2)
    {
        return (v1 - v2).sqrMagnitude;
    }
    
    float mapValue(float mainValue, float inValueMin, float inValueMax, float outValueMin, float outValueMax)
    {
        return (mainValue - inValueMin) * (outValueMax - outValueMin) / (inValueMax - inValueMin) + outValueMin;
    }
