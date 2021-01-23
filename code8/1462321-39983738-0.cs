    public Result DisplayMessage(string message)
    {
         // some error handling
         if(errorOccurred)
         {
             return new Result { IsError = true, ErrorMessage = "error occurred"}
         }
         eventAggregator.GetEvent<DisplayMessageEvent>().Publish(new DisplayMessageEventArg(message));
         var result = new TaskCompletionSource<Result>();
         eventAggregator.GetEvent<DisplayMessageAnswerEvent>().Subscribe( x => result.SetResult( x ) );
         return result.Result;
    }
