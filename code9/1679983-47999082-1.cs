    double[,] mMemberEndforces = new double[mbCount, 12];
    double[,] mDeflection = new double[mbCount + 1, 6];
    for(int x = 0; x < mbCount; x++)
    {
        for(int y = 0; y < 12; y++)
            mMemberEndforces[x,y] = MemberEndforces[x * 12 + y];
    }
    for(int x = 0; x < mbCount + 1; x++)
    {
        for(int y = 0; y < 6; y++)
            mMemberEndforces[x,y] = MemberEndforces[x * 6 + y];
    }
