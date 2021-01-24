        static private Func<T, int> X;
        static private Func<T, int> Y;
        static MyAlgo()
        {
            //check here!
            var type = typeof(T);
            var x = type.GetProperty("X");
            if (x == null) { throw new NotSupportedException($"missing X property in { type }"); }
            var y = type.GetProperty("Y");
            if (y == null) { throw new NotSupportedException($"missing Y property in { type }"); }
            // you can store delegate to retreive X & Y in static fields.
            MyAlgo<T>.X = Delegate.CreateDelegate(typeof(Func<T, int>), x.GetGetMethod());
            MyAlgo<T>.Y = Delegate.CreateDelegate(typeof(Func<T, int>), y.GetGetMethod());
        }
    }
