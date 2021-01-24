    public static void Main(string[] args) {
    
        var queues = new Queue<int>[8];
    
        // Possibly some other stuff
    
        // Initialise all values
        for (var i = 0; i < queues.Length; i++) {
            // Accounting for maybe already sporadically initialising values
            queues[i] = (queues[i]) ?? new Queue<int>();
        }
        // Do whatever
    
    }
