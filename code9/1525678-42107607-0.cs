    public async void DoSomethingAsync(MyRequest request)
    {
         try {
             await Customer.GetCustomersAsync(request);
             Result(request);      
         }
         catch (Exception ex) {
             Fault(request);
         }
    }
