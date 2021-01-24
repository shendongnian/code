    class EventTest
    {
      void Test()
      {
        Channel              c  = null ;
        IChannelEvents_Event ee = c as IChannelEvents_Event ;
  
        ee.OnlineValue += OnlineValue ;
      }
  
      void OnlineValue ( double        dValue,
                         double        dMax,
                         double        dMin,
                         string        Unit,
                         bool          bOverloaded )
      {
      }
    }
