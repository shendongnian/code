    static InventoryData ParseInventoryData( string data )
    {
        var parts = data.Split( '|' );
        var headparts = parts.First().Split( ':' );
        var result = new InventoryData
        {
            Inv = headparts[0],
            Date = DateTime.ParseExact( headparts[1], "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture ),
            Term = headparts[2],
            Articles = parts.Skip( 1 ).Select( part => ParseInventoryArticle( part ) ).ToList(),
        };
        return result;
    }
    static InventoryArticle ParseInventoryArticle( string data )
    {
        var parts = data.Split( ':' );
        var result = new InventoryArticle
        {
            Quantity = int.Parse( parts[0] ),
            Whatever = parts[1],
            Description = parts[2],
            Price = decimal.Parse( parts[3], System.Globalization.CultureInfo.InvariantCulture ),
            Tax = parts[4] == "Y",
        };
        return result;
    }
