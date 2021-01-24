    private float totalCount = 0f;
    private float countOne = 1f;
    private List<DateTime> pressedTime = new List<DateTime>();
    
    void Update(){
    
        if(Input.GetKeyDown(KeyCode.F)){
    
            pressedTime.Add(DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")));
        }
    
        if (pressedTime.Count == 5){
            if ( (DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")) - pressedTime[0]).Seconds <= 1)
                do stuff
            pressedTime.Remove(0);
        }
    }
