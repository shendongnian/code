       class Program
        {
            enum EVENTS
            {
                EVENT1,
                EVENT2,
                EVENT3,
                EVENT4,
            }
            static void Main(string[] args)
            {
               
            }
            static void EventHandler(EVENTS myEvent)
            {
                    Object thisLock = new Object();
                    lock (thisLock)
                    {
                        switch (myEvent)
                        {
                            case EVENTS.EVENT1 :
                                break;
                            case EVENTS.EVENT2:
                                break;
                            case EVENTS.EVENT3:
                                break;
                            case EVENTS.EVENT4:
                                break;
                        }
                    }
            }
        }
