    protected override Derived.Finalize() {
        try {
            Console.WriteLine("Derived finalizer called"); 
        }
        finally {
            base.Finalize();
        }
    }
