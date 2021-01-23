    void p<T1>(T1 message)
    {
        Debug.Log(message);
    }
    
    void p<T1, T2>(T1 message, T2 context)
    {
        Debug.Log(message, context as Object);
    }
