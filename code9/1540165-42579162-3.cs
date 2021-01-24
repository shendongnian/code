     MyViewModelToolBar = new ViewModelToolBar();
     ViewModelToolBar.Notify += ViewModelToolBar_Notify;
    
      private void ViewModelToolBar_Notify(object sender, EventArgs e)
            {
                switch (sender.ToString())
                {
                    case "Case1":
                       "perform your operation"
                        break;
                    case "Case2":
                       ...
                        break;
                    case "Case3":
                       ...
                        break;
                                  }
            }
