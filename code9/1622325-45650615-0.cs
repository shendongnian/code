    private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs elapsedEventArgs)
    {
         countDownSeconds--;
         // This is what I expect to happen when the timer reaches 0
         if (countDownSeconds == 0)
         {
              Console.WriteLine("Timer Finished==========================");
              Handler handler = new Handler(Looper.MainLooper);
              //Returns the application's main looper, which lives in the main thread of the application.
              Action myAction = () =>
              {
                  Toast.MakeText(this, "Timer Finished", ToastLength.Short).Show();
               };
               handler.Post(myAction);
               myTimer.Stop();
         }
    }
