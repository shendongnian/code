    class Program {
        public static void Main() {
            var errors = (new TestDBEntities()).Errors.ToList();
            // create list of references
            var refs = errors.Select(c => new WeakReference(c)).ToList();
            // collect
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine(refs.All(c => !c.IsAlive) ? "all collected" : "something alive");
            Console.WriteLine("done");            
        }
    }
