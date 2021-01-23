    private Task<string> MakeContactlessPaymentAsync()
    {
         TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
         Task.Run(() =>
         {
             ContactlessTerminal.wsContactlessTerminal objContactlessTerminal = 
                  new ContactlessTerminal.wsContactlessTerminal();
             var strMessage = objContactlessTerminal.fnMakeContactlessPayment();
             tcs.SetResult(strMessage);
          });
         return tcs.Task;
    }
    public async Task<ActionResult> GizmosAsync()
    {
        var result = await MakeContactlessPaymentAsync();       
        return View(result); //return the string as a model for that view
    }
