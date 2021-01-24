    private float totalCount = 0f;
    private float countOne = 1f;
    private Queue<DateTime> myQ = new Queue<DateTime>();
    
    void Update(){
    
        if(Input.GetKeyDown(KeyCode.F)){
    
            pressedTime.Enqueue(DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")));
        }
    
        if (pressedTime.Count == 5){
            if ( (DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")) - pressedTime.Peek()).Seconds <= 1)
                do stuff
            pressedTime.Dequeue();
        }
    }
