    public static void ShallowCloneWithDeepClonerLibrary(this object obj, int times)
        {
            Console.WriteLine($"Performing {times.ToString("##,###")} cloning operations with DeepCloner's ShallowClone method:");
            var sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < times - 1; i++) obj.ShallowClone();
            var clone = obj.ShallowClone();
            sw.Stop();
            Console.WriteLine($"Total milliseconds elapsed: {sw.ElapsedMilliseconds}");
            Console.WriteLine($"Are both the same: {obj == clone}");
            Console.WriteLine($"Cloned object: {Environment.NewLine}{clone}{Environment.NewLine}");
        }
    
        public static void ShallowCloneWithMemberWiseClone(this Foo obj, int times)
        {
            Console.WriteLine($"Performing {times.ToString("##,###")} cloning operations wiht MemberwiseClone:");
            var sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < times - 1; i++) obj.Clone();
            var clone = obj.Clone();
            sw.Stop();
            Console.WriteLine($"Total milliseconds: {sw.ElapsedMilliseconds}");
            Console.WriteLine($"Are both the same: {obj == clone}");
            Console.WriteLine($"Cloned object: {Environment.NewLine}{clone}{Environment.NewLine}");
        }
    
        public static void ShallowCloneWithDelegatesAndReflection(this object obj, int times)
        {
            Console.WriteLine(
                $"Performing {times.ToString("##,###")} cloning operations by encapsulating MemberwiseClone method info in a delegate:");
            var sw = new Stopwatch();
            sw.Start();
            var type = obj.GetType();
            var clone = Activator.CreateInstance(type);
            var memberWiseClone = type.GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic);
            var memberWiseCloneDelegate =
                (Func<object, object>)Delegate.CreateDelegate(typeof(Func<object, object>), memberWiseClone);
            for (var i = 0; i < times; i++) clone = memberWiseCloneDelegate(obj);
            sw.Stop();
            Console.WriteLine($"Total milliseconds: {sw.ElapsedMilliseconds}");
            Console.WriteLine($"Are both the same: {obj == clone}");
            Console.WriteLine($"Cloned object: {Environment.NewLine}{clone}{Environment.NewLine}");
        }
    
        public static void ShallowCloneWithReflection(this object obj, int times)
        {
            Console.WriteLine($"Performing {times.ToString("##,###")} cloning operations manually with reflection and MemberwiseClone:");
            var sw = new Stopwatch();
            sw.Start();
            var type = obj.GetType();
            var memberWiseClone = type.GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic);
            var clone = Activator.CreateInstance(type);
            for (var i = 0; i < times - 1; i++)
                clone = memberWiseClone.Invoke(obj, null);
            sw.Stop();
            Console.WriteLine($"Total milliseconds: {sw.ElapsedMilliseconds}{Environment.NewLine}");
            Console.WriteLine($"Are both the same: {obj == clone}");
            Console.WriteLine($"Cloned object: {Environment.NewLine}{clone}{Environment.NewLine}");
        }
