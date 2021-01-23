    if (Window.Current != null)
    {
         if (Window.Current.Content != null)
         {
               Window.Current.Activate();
               var view = CoreApplication.GetCurrentView();
         }
    }
