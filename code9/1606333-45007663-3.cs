    private async void ThreadMethod()
    {
         while(true)
         {
             if(CurrentItem != null)
             {
                 HandleCurrentItem();
             }
             await Task.Delay(200);
         }
    }
