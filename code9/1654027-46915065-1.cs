    void RefreshScreen(NSTimer obj)
    {
          Debug.WriteLine("Elapsed");                      
          UIStoryboard StoryBoard = UIStoryboard.FromName("Main", null);
          ViewController uvc = StoryBoard.InstantiateViewController("StartScreenController") as ViewController;
              
         //Navigate using the navController Instance from the appDelgate
         ((AppDelegate)UIApplication.SharedApplication.Delegate).navController.PushViewController(uvc, true);
    }
