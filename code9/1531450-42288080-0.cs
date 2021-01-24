    public IEnumerable<int> CountToTen()
    {
      for (int i = 1; i <= 10; ++i)
      {
        yield return i;
      }
    }
