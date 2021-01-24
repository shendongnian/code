    public static void Main(string[] args)
    {
        // demo data
        var area = new Tile[5, 5];
        for (var j = 0; j < 5; j++)
            for (var i = 0; i < 5; i++)
                area[i, j] = new Tile() { height = j * i, terrain = 99 };
        // get the height's only
        var onlyHeights = Enumerable
            .Range(0, 25)
            .Aggregate(new int[5, 5], (acc, i) =>
        {
            acc[i / 5, i % 5] = area[i / 5, i % 5].height;
            return acc;
        });
    }
