    public GameObject customGameObject1;
    public GameObject customGameObject2;
    void Start()
    {
        generateEnviroment()
    }
    
    
    void generateEnviroment()
    {
        //In case you want to add other type of GameObject, like a car or sth you have created:
        GameObject myInstantiatedGameObject = GameObject.Instantiate (customGameObject1);
        //You change its position
        myInstantiatedGameObject.transform.position = new Vector3(0, 0.5F, 0);
        // Widen the object by 0.1
        myInstantiatedGameObject.transform.localScale += new Vector3(0.1F, 0, 0);
        //Change material properties, assuming it has a material component
        Renderer rend = myInstantiatedGameObject.GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", Color.red);
        ...
    }
