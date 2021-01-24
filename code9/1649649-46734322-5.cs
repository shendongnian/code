    public GameObject objMeshToExport;
    
    void Start()
    {
        string path = Path.Combine(Application.persistentDataPath, "data");
        path = Path.Combine(path, "carmodel" + ".obj");
    
        //Create Directory if it does not exist
        if (!Directory.Exists(Path.GetDirectoryName(path)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
        }
        MeshFilter meshFilter = objMeshToExport.GetComponent<MeshFilter>();
        ObjExporter.MeshToFile(meshFilter, path);
    }
