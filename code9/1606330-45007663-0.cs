    private async void ThreadMethod()
    {
         while(true)
         {
             if(CurrentItem != null)
             {
                 HandleCurrentItem();
             }
             Task.Delay(200);
         }
    }
