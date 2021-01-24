    // Your mesh data from the point cloud scan of a room
    long[] indices = ...;
    Vector3[] positions = = ...;
    // Split your mesh data into two parts:
    // one that have 60000 vertices and another that have 40000 vertices.
    // create meshes
    {
        Mesh mesh = new Mesh();
        GameObject obj = new GameObject();
        obj.AddComponent<MeshFilter>().sharedMesh = mesh;
        var positions = new Vector3[60000];
        var indices = new int[count_of_indices];//The value of count_of_indices depends on how you split the mesh data.
        // copy first 60000 vertices to positions and indices
        mesh.vertices = positions;
        mesh.triangles = indices;
    }
    {
        Mesh mesh = new Mesh();
        GameObject obj = new GameObject();
        obj.AddComponent<MeshFilter>().sharedMesh = mesh;
        var positions = new Vector3[4000];
        var indices = new int[count_of_indices];
        // copy the remaining 40000 vertices to positions and indices
        mesh.vertices = positions;
        mesh.triangles = indices;
    }
