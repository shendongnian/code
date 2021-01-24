    @using Nop.Core.Infrastructure;
    @using Nop.Core;
    <ul class="method-list" id="payment-method-block">
      @for (int i = 0; i < Model.PaymentMethods.Count; i++)
      {                    
          var customerEmail = EngineContext.Current.Resolve<IWorkContext>().CurrentCustomer.Email;
    
          var paymentMethod = Model.PaymentMethods[i];
    
          string _paymentMethodSystemName = paymentMethod.PaymentMethodSystemName;
    
          if (_paymentMethodSystemName == "Payments.CheckMoneyOrder")
          {
              continue;
          }
    
          var paymentMethodName = paymentMethod.Name;
      }
      ...
      .....
