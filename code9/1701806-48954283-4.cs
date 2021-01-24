    private void UpdateLines()
    {
        GameObject[] drawnLineGameObjects = GameObject.FindGameObjectsWithTag("DrawnLines");
        foreach (var lineObject in drawnLineGameObjects)
        {
            LineRenderer drawnLine = lineObject.GetComponent<LineRenderer>();
            if (drawnLine != null)
            {
                // Do stuff to your Line Renderer Here
            }
        }
    }
