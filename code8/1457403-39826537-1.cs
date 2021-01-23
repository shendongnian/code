    class SomeClass
    {
         private event Action SomeEvent;
         // the event is private, and we can only subscribe
         // through this method
         public void Subscribe(Action callback)
         {
             // 'callback' already attached?
             if (SomeEvent != null && SomeEvent.GetInvocationList().Contains(action))
                 return;
             SomeEvent += callback;
         }
         public void Unsubscribe(Action callback)
         {
             SomeEvent -= callback;           
         }
    }
