    public IEnumerator PlaceTower(Vector3 pos, int tType)
    {
        while (!F_BotsManager.bots.CheckPathNotBlocked(pos))
        {
            Debug.Log("waiting!");
            yield return null;
        }
    
        // rest of my code to place a tower
    }
