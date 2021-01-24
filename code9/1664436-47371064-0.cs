    public UnityEvent myEvent;
        
        
    void OnCollisionEnter(Collision collision)
    {
        //do your collsiion logic here
        myEvent.Invoke();
    }
