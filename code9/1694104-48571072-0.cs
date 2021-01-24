    static void SafelyDoSomething(string key) {
        try { startRID(key); }
        catch(Exception ex) {
             // lots of logging here
             Console.Error.WriteLine(ex); // add more than this!
        }
    }
