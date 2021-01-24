    public int GenerateAge(int popSeed)
    {
        long age = gameSeed;
        for (int i = 0; i < popSeed; ++i)
        {
            age = (48271 * age) % int.MaxValue;
        }
        return (int)(1 + age % 99);
    }
