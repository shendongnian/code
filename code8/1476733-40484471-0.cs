    class MyActivity : Activity {
    
       IDisposable subscription;
    
       void OnStart() {
          subscription = Observable
              // Adapt a delegate to the event signature and subscribe to the event (unsubscribing when subscription disposed)
              .FromEventPattern<EventHandler,EventArgs>(handler => (s,e) => handler(e), handler => button1.TouchUpInside += handler, handler => button1.TouchUpInside -= handler)               
              // Emit a new observable containing the data "from another source"
              .Select(args => Observable.Return("1", "2", "3", "4"))
              // Dispose any subscription to the previous observable and subscribe to the new observable emitted from above    	      
    	      .Switch()
              .Subscribe(UpdateUiOnEvent);
       }
    
       void OnStop() {
          subscription.Dispose();
       }
    }
