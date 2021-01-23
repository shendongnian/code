    var myClassWithDependencies = myContainer.Construct<MyClassWithDependencies>();
    
    public class MyClassWithDependencies
    {
      public MyClassWithDependencies(
          IFacebookClient facebookClient,
          IGooglePlusClient googlePlusClient,
          ITwitterClient twitterClient,
          ISalesforceClient salesforceClient,
          IReportRepository reportRepo,
          IUserRepository userRepo)
        {
          
        }
}
