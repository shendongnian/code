    private float totalCount = 0f;
    private float countOne = 1f;
    private List<DateTime> pressedTime = new List<DateTime>();
    
    void Update(){
    
        if(Input.GetKeyDown(KeyCode.F)){
    
            pressedTime.Add(DateTime.Now);
        }
    
        if (pressedTime.Count == 5){
            if ( (DateTime.Now - pressedTime[0]).Seconds <= 1)
                do stuff
            pressedTime.Remove(0);
        }
    }
