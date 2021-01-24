    protected override bool OnBackButtonPressed()
        {
            bool returnvalue = true;
            Device.BeginInvokeOnMainThread(async () =>
            {
              vawait DisplayActionSheet("ActionSheet: Send to?", "null", null, "Facebook", "twitter", "Instagram");
                    switch (action)
                    {
                        case "Facebook":
                         // My code
                CallPage();  Here i want to redirect on different page 
               break;
                    }
            });
          return true; // always return true
      }
  
      ...
      public async Task RetrunToPreviousPage()
      { 
          Navigation.InsertPageBefore(new InboundOrderList(), this);
          await Navigation.PopAsync();            
      }
