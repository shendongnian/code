    public class MyHub : Hub
    {
      public void StartProcess()
      {
        // DO WORK
        // Call Client!
        Clients().Client(id).ProcessFinished()
      }
    }
