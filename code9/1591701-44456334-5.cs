    void Start()
    {
        GameObject[] objByNames = FindInActiveObjectsByName("Cube");
        GameObject[] objByTags = FindInActiveObjectsByTag("CubeTag");
        GameObject[] objByLayers = FindInActiveObjectsByLayer(LayerMask.NameToLayer("CubeLayer"));
    }
