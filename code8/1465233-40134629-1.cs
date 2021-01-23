    public List<Transform> firedpoints;
    
    // Returns available firing position, if any
    public Transform GetRandomFiringPosition()
    {
        if (firedpoints.Count > 0)
        {
            // Get reference to transform, then remove it from list
            int newPositionIndex = Random.Range (0, firedpoints.Length);
            Transform returnedPosition = firedpoints[newPositionIndex];
            firedpoints.RemoveAt(newPositionIndex);
            return returnedPosition;
        }
        else
        {
            // Or you can specify some default transform
            return null;
        }
    }
    
    // Makes firing position available for use
    public void RegisterFiringPosition(Transform newPosition)
    {
        firedpoints.Add(newPosition);
    }
