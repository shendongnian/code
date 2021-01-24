    public static IEnumerable<string> ReadLastLines(string path, int count)
    {
        if (count < 1)
            return Enumerable.Empty<string>();
        var queue = new Queue<string>(count);
        foreach (var line in File.ReadLines(path))
        {
            if (queue.Count == count)
                queue.Dequeue();
             queue.Enqueue(line);
        }
        return queue;
    }
