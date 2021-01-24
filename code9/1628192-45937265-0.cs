    public Dictionary<string, GameObject> Premio;
    
    
    private void Show(int itemNumber)
    {
        Debug.Log("Premio: " +
                  Premio.Keys.ToList()[itemNumber] +
                  Premio[Premio.Keys.ToList()[itemNumber]);
    
    }
    
    private void ShowAll()
    {
        foreach(var key in Premio.Keys)
        {
              Debug.Log("Premio: " + key + Premio[key]);
        }
    }
       
