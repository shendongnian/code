    public GameObject objMeshToExport;
    
    void Start()
    {
        string path = Path.Combine(Application.persistentDataPath, "data");
        path = Path.Combine(path, "carmodel"+ ".fbx");
    
        //Create Directory if it does not exist
        if (!Directory.Exists(Path.GetDirectoryName(path)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
        }
        FBXExporter.ExportGameObjToFBX(objMeshToExport, path, true, true);
    }
