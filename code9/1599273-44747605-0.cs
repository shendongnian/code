    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using System.ServiceProcess;
    
    namespace TEST.MY.SERVICE
    {
        partial class MyService : ServiceBase
        {
          private Task _initializationTask;
          private CancellationTokenSource _initializationCancelTokenSource;
          private CancellationToken _intitializationCancellationToken;
        
          public MyService()
          {
              InitializeComponent();
          }
        
          protected override void OnStart(string[] args)
          {
            _initializationCancelTokenSource = new CancellationTokenSource();
            _intitializationCancellationToken = _initializationCancelTokenSource.Token;
            _initializationTask = Task.Run(() =>
            {
              //Kick off polling from here that also uses _intitializationCancellationToken, so that when _initializationCancelTokenSource.Cancel() is invoked from OnStop it will start cancellation chain reaction to stop all running activity. You can pass it even into your methods and check _intitializationCancellationToken.IsCancellationRequested and take appropriate actions.
           
                    //using the Task timer from the other stack overflow post, You could do something like
                    Task perdiodicTask = PeriodicTaskFactory.Start(() =>
                    {
                        Console.WriteLine(DateTime.Now);
                        //execute your logic here that has to run periodically
                    }, intervalInMilliseconds: 5000, // fire every 5 seconds...
                       cancelToken: _intitializationCancellationToken); // Using same cancellation token to manage timer cancellation
        
                    perdiodicTask.ContinueWith(_ =>
                    {
                        Console.WriteLine("Finished!");
                    }).Wait();
        
            }, _intitializationCancellationToken)
            .ContinueWith(t =>
            {
              //deal with any task related errors
            },TaskContinuationOptions.OnlyOnFaulted);
          }
        
          protected override void OnStop()
          {
            try
             {
               _initializationCancelTokenSource?.Cancel();
               _initializationCancelTokenSource?.Dispose();
               _initializationTask?.Dispose();
              }
              catch (Exception stopException)
              {
                        //log any errors
              }
          }
      }
    }
