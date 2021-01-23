    using (var gen = MakeId().GetEnumerator()) {
        gen.MoveNext();
        Console.WriteLine(gen.Current); // 0
        gen.MoveNext();
        Console.WriteLine(gen.Current); // 1
        gen.MoveNext();
        Console.WriteLine(gen.Current); // 2
    }
