    public Transform [] spawns;
    private int spawnsCount;
    // Index must be in the range [0 ... spawnsCount - 1] and spawnsCount > 0.
    public DeleteSpawnAt(int index)
    {
        spawnsCount--;
        spawns[index] = spawns[spawnsCount];
        spawns[spawnsCount] = null;
    }
