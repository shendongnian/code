    public partial class App : Application
    {
    
       protected override void OnStart()
       {
          // Your App On start code should be here...
          // and then:
          Task.Run(() =>
            {
                //Add your code here, it might looks like:
                CheckDatabase();
                MakeAnUpdateDependingOnDatabase();
            });
       }
