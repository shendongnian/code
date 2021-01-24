    void attachMeshFilter(GameObject target, Mesh mesh)
    {
        MeshFilter mF = target.AddComponent<MeshFilter>();
        mF.mesh = mesh;
    }
    
    Material createMaterial()
    {
        Material mat = new Material(Shader.Find("Standard"));
        return mat;
    }
    
    void attachMeshRenderer(GameObject target, Material mat)
    {
        MeshRenderer mR = target.AddComponent<MeshRenderer>();
        mR.material = mat;
    }
