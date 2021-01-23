    public void OnStatusChanged()
        {
            if (this.Dispatcher.CheckAccess())
            {
                switch (UpdaterStatus.CurrentStatus)
                {
                    case UpdateStatus.UpdateFound:
                        {
                            Message ToAdd = new Message("some params"); //Exception here
                            MessagesManager.AddNewMessage(ToAdd);
                            break;
                        }
                    //some other cases
                }
            }
            else
                this.Dispatcher.Invoke(new Action(OnStatusChanged));
        }   
