     public class YourClassName {
        {
                    private string mEventID;
            public string EventID{
                get { return mEventID; }
                set { SetProperty(ref mEventID, value); }
            }
    
                    private string mEventDescription;
            public string EventDescription{
                get { return mEventDescription; }
                set { SetProperty(ref mEventDescription, value); }
            }
        }
