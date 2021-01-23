    using (var gen = MakeId().GetEnumerator()) {                
        Console.WriteLine(gen.NextValue()); // 0                
        Console.WriteLine(gen.NextValue()); // 1                
        Console.WriteLine(gen.NextValue()); // 2
    }
