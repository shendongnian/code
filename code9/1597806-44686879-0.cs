    public class ProdIgnoreAttribute : Attribute, ITestAction
    {
      public void BeforeTest(TestDetails details)
      {
        bool ignore = StaticInfoHelper.VrCurrentEnv == (int)RunEnv.PROD;
        if (ignore)
          Assert.Ignore("Test ignored during Prod runs");
      }
    
      //stub out rest of interface
    }
