            var currentDriver = e.UserState as DownId;
            if (downloadlist[current].IsCanceling == true)
            {              
                downloadlist[current].IsCanceling = false;
                downloadlist[current].Client.CancelAsync();
            }
            else
            {
              //Update progress etc.
              // beware of not using UI Elements here, caused UI Lags
              // and can be a problem within threads
              // if necessary use  Invoke(new MethodInvoker(delegate {  ...}));
            }
