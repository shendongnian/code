    public string FLogin(int waitTime);
    public string BlendDualCall()
    {
      var yResult = YLogin(1000);
      var fResult = FLogin(2000);
      ...
    }
