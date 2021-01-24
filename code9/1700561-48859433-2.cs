    public GenericRepositoryTest<MasterData> MastrData
    {
       get
        {
          return this.mastrData ?? new GenericRepositoryTest<MasterData>(context);
        }
    }
