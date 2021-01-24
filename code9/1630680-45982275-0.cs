    public class SomeClass 
    {
        private static EventOperations eventOperation = null;
        
        void SomeMethod()
        {
            if(true)
            {
                eventOperation = EventOperations.Cancel; // whatever value you set here, it'll be propagated to all the instances of some class.
            }
        }
    }
