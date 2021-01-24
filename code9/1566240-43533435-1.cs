    public void Lines()
    {
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;
    
        seg = points.Length;
        vP = new Vector3[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            vP[i] = points[i].position;
        }
        for (int i = 0; i < seg; i++)
        {
            float t = i / (float)seg;
            lineRenderer.numPositions = vP.Length;
            lineRenderer.SetPositions(vP);
        }
    }
