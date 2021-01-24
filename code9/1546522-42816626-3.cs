    public List<Vector3> GetMidpoints(List<Vector3> vertices)
    {
        // Preallocate memory for the list so we don't 
        // need to worry about reallocating on insertions
        List<Vector3> midpoints = new List<Vector3>(vertices.Count * vertices.Count);
        for (int i = 0; i < vertices.Count; i++)
        {
            for (int j = 0; j < vertices.Count; j++)
            {
                if (vertices[i].x != vertices[j].x && vertices[i].z != vertices[j].z)
                    continue;
                midpoints.Add(new Vector3(
                                (vertices[i].x + vertices[j].x) / 2,
                                (vertices[i].y + vertices[j].y) / 2,
                                (vertices[i].z + vertices[j].z) / 2
                ));
            }
        }
        return midpoints;
    }
