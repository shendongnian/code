    public static void Main(string[] args) {
    
        var queues = new Queue<int>[8];
    
        // Possibly some other stuff
    
        // Initialise all values
        foreach (var queue in queues)
            // Accounting for maybe already sporadically initialising values
            queue = queue ?? new Queue<int>();
    
        // Do whatever
    
    }
