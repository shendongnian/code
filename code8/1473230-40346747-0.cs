    class ObjectNotGettingGarbageCollected{
         Timer _timer; //won't be GC'd
         SomeMethod(){
               _timer = new Timer(UndoDeleteTimerFinish, email, UndoBannerDisappearTime, Timeout.Infinite)
         }
    }
