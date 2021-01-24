    //Draws lines through the provided vertices
    void drawLine(Vector3[] verticesToDraw)
    {
        Color beginColor = Color.yellow;
        Color endColor = Color.red;
        float lineWidth = 0.3f;
    
        //Create a Line Renderer Obj then make it this GameObject a parent of it
        GameObject childLineRendererObj = new GameObject("LineObj");
        childLineRendererObj.transform.SetParent(transform);
    
        //Create new Line Renderer if it does not exist
        LineRenderer lineRenderer = childLineRendererObj.GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = childLineRendererObj.AddComponent<LineRenderer>();
        }
    
        //Assign Material to the new Line Renderer
        //Hidden/Internal-Colored
        //Particles/Additive
        lineRenderer.material = new Material(Shader.Find("Hidden/Internal-Colored"));
    
    
        //Set color
        lineRenderer.startColor = beginColor;
        lineRenderer.endColor = endColor;
    
        //Set width
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
    
        //Convert local to world points
        for (int i = 0; i < verticesToDraw.Length; i++)
        {
            verticesToDraw[i] = gameObject.transform.TransformPoint(verticesToDraw[i]);
        }
    
        //5. Set the SetVertexCount of the LineRenderer to the Length of the points
        lineRenderer.positionCount = verticesToDraw.Length + 1;
    
        for (int i = 0; i < verticesToDraw.Length; i++)
        {
            //Draw the  line
            Vector3 finalLine = verticesToDraw[i];
            lineRenderer.SetPosition(i, finalLine);
    
            //Check if this is the last loop. Now Close the Line drawn
            if (i == (verticesToDraw.Length - 1))
            {
                finalLine = verticesToDraw[0];
                lineRenderer.SetPosition(verticesToDraw.Length, finalLine);
            }
        }
    }
