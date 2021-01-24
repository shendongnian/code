    public void Main()
    {   
        MyMeshFace[] m_meshFaces = new MyMeshFace[m_mesh.Faces.Count];
        for (var f = 0; f < m_faceInfo.GetLength(0); f++)
        {
            var face = m_meshFaces[f]; // <---
            face.Init(m_mesh, f);
            face.SetFaceData(m_mesh);
        }
        for (var x = 0; x < m_meshFaces.GetLength(0); x++)
        {
            var face = m_meshFaces[x]; // <---
            if (face.DoSomething())
                Print("Did something!");  # <-- This never happens
        }
    }
