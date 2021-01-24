    public void Test()
    {
      try
      {
        Deeper();
      }
      catch (Exception ex)
      {
        throw; //throw statement 
      }
    }
    private static void Deeper()
    {
      int a = 10;
      int b = 10;
      int c = 10 / (a - b);
    }
