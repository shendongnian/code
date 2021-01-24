    public List<Vector3> GetFloorVertices(List<Vector3> vertices)
    {
        // Preallocate memory for the list so we don't 
        // need to worry about reallocating on insertions
        List<Vector3> floorVerts = new List<Vector3>(vertices.Count);
        float avg = vertices.Average(v => v.y);
        for (int i = 0; i < vertices.Count; i++)
        {
            if (vertices[i].y < avg)
            {
                floorVerts.Add(vertices[i]);
            }
        }
        return floorVerts;
    }
