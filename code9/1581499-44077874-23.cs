    private static void Main()
    {
        List<ISegment> segments = GenerateSegmentList();
        List<List<ISegment>> segmentChains = GetSegmentChains(segments);
        for(int i = 0; i < segmentChains.Count; i++)
        {
            Console.WriteLine($"Segment Chain #{i + 1}: {string.Join(" => ", segmentChains[i])}");
        }
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
