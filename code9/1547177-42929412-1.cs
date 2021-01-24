    class Program {
        // represents context reference you hold elsewhere
        static TestDBEntities _context = new TestDBEntities();
        public static void Main() {
            var errors = _context.Errors.ToList();
            // create list of references
            var refs = errors.Select(c => new WeakReference(c)).ToList();
            // collect
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine(refs.All(c => !c.IsAlive) ? "all collected" : "something alive");
            Console.WriteLine("done");
            Console.ReadKey();
        }                
    }
