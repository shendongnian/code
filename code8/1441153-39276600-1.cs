      public sealed class RuntimeComponentClass : IBackgroundTask
     {
     BackgroundTaskDeferral _deferral;
     public void Run(IBackgroundTaskInstance taskInstance)
     {
          _deferral = taskInstance.GetDeferral();
            AStaticClass.Object is accessible
           //here i need to access static object from main project 
          _deferral.Complete();
     }
     }
