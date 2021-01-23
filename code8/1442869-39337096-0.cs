    private bool CheckIndex(int cIndex, bool a2DCollider)
    {
        if (a2DCollider && floatingObjects2D[cIndex] == null)
           floatingObjects2D.RemoveAt(cIndex);          
        else if (floatingObjects3D[cIndex] == null)               
           floatingObjects3D.RemoveAt(cIndex)            
        return true;
    }
