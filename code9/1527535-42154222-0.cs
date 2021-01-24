    // A delegate type for hooking up change notifications.
      public delegate void ChangedEventHandler(object sender, EventArgs e);
     // A class that works just like ArrayList, but sends event
     // notifications whenever the list changes.
     public class ListWithChangedEvent: ArrayList 
     {
        // An event that clients can use to be notified whenever the
        // elements of the list change.
        public event ChangedEventHandler Changed;
        // Invoke the Changed event; called whenever list changes
        protected virtual void OnChanged(EventArgs e) 
        {
          if (Changed != null)
           //you raise the event here.
            Changed(this, e);
        }
     }
