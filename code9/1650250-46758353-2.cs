    bool isObjectHere(Vector3 position)
    {
        Collider[] intersecting = Physics.OverlapSphere(position, 0.01f);
        if (!intersecting.Length == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
