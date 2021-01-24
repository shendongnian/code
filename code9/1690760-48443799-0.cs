    public delegate void MyDel();
    // The two following behaves the same
    public MyDel myDel;
    public Action myAction;
    public event Action myEvent;
    void Start(){
         if(myAction != null){ myAction(); }
         if(myEvent != null) { myEvent(); }
         if(myEvent != null) { myEvent.Invoke(); }
    }
