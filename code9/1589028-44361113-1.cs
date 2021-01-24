    public GameObject line; //Set your line image via the inspector here
    private int pieces = 8;
    
    public void DrawLines()
    {
       int linecount = pieces/2;
       float angle = 360 / linecount;
       for(int i = 0; i < linecount; i++)
       {
           GameObject clone = Instantiate(line, Vector3.zero, 
           Quaternion.Euler(0,0,(angle*i)));
       }
    }
