    public Transform [] spawns;
    private int spawnsCount;
    // index must be in the range [0 ... spawnsCount - 1].
    public DeleteSpawnAt(int index)
    {
        spawnsCount--;
        if (spawnsCount > 0) {
           spawns[index] = spawns[spawnsCount];
        }
        spawns[spawnsCount] = null;
    }
