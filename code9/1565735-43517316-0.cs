    private Action someevent; // Declare a private delegate
    
    public event Action OutwardFacingSomeEvent
    {
        add 
        { 
           //write custom code
           someevent += value; 
        }
        remove 
        { 
             someevent -= value; 
             //write custom code
        }
    }
