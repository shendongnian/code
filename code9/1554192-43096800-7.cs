    public class YourClassName {
        
    	public YourClassName(string eventId, string eventDescr)
    	{
    		EventID = eventId;
    		EventDescription = eventDescr;
    	}
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
