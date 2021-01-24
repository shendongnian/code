    private void getTiles(int x, int y, int moves)
    {
        List<GameObject> moveTiles = new List<GameObject>();
        // sweep through horizontally
        for (int i = -moves; i <= moves; i++)
        {
            // at each step horizontally, sweep vertically as far as allowed
            int jRange = moves - Math.Abs(i);
            for (int j = -jRange; j <= jRange; j++)
            {
                // add (i + x, j + y) to moveTiles, maybe skip when (i, j) = (0, 0)?
            }
        }
    }
