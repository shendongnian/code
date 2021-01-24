    static void Main(string[] args) {
        var ob = new object();
        Write(ob);
        var wr = new WeakReference(ob);
        GC.Collect(2, GCCollectionMode.Forced);            
        Console.WriteLine(wr.IsAlive);
        Console.ReadKey();            
    }
    static void Write(object ob) {
        Console.WriteLine(ob);
    }
