    public IEnumerable<Region> GetUnreadBlocks()
    {
        var blocks = new LinkedList<Region>(_blocks.OrderBy(s => s.Position));
        var curr = blocks.First;
        // nothing explored
        if (curr == null)
        {
            yield return new Region
            {
                Position = 0,
                Length = BaseStream.Length
            };
            yield break;
        }
        // account for beginning of file
        if (curr.Value.Position > 0)
            yield return new Region
            {
                Position = 0,
                Length = curr.Value.Position
            };
        // in-between
        while (true)
        {
            var next = curr.Next;
            if (next == null)
                break;
            var position = curr.Value.Position + curr.Value.Length;
            var length = next.Value.Position - position;
            if (length > 0)
                yield return new Region(position, length);
            curr = next;
        }
        // account for end of file
        if (curr.Value.Position + curr.Value.Length < BaseStream.Length)
            yield return new Region
            {
                Position = curr.Value.Position + curr.Value.Length,
                Length = BaseStream.Length - (curr.Value.Position + curr.Value.Length)
            };
    }
