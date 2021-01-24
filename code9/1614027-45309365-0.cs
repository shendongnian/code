    public GameObject[] allCubes;
    
    int findIndex(GameObject target)
    {
        for (int i = 0; i < allCubes.Length; i++)
        {
            //If we find the index return the current index
            if (allCubes[i] == target)
            {
                return i;
            }
        }
        //Nothing found. Return a negative number
        return -1;
    }
