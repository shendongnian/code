    void ProcessMessages(IEnumerable<Msg> messages) {
        foreach (var m in messages) {
            ProcessSingleMessage((dynamic)m);
        }
    }
    
    void ProcessSingleMessage(Message1 m1) {
        // Access properties of m1 as needed
    }
    void ProcessSingleMessage(Message2 m2) {
        // Access properties of m2 as needed
    }
    ...
    // Catch-all handler
    void ProcessSingleMessage(Msg m) {
        throw new InvalidOperationException("Received a message of unknown type: "+m.GetType());
    }
