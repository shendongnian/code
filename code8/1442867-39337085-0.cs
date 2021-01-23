    private bool CheckIndex(int cIndex, bool a2DCollider)
    {
        if (a2DCollider)
        {
            if (floatingObjects2D.Count <= cIndex)
            {
                return true;
            }
            if (floatingObjects2D[cIndex] == null)
            {
                floatingObjects2D.RemoveAt(cIndex);
                return true;
            }
        }
        else
        {
            if (floatingObjects3D.Count <= cIndex)
                return true;
            if (floatingObjects3D[cIndex] == null)
            {
                floatingObjects3D.RemoveAt(cIndex);
                return true;
            }
        }
        return false;
    }
