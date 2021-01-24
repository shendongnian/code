    TableA
    {
        int IDTableA { get; set; }
        ICollection<TableABC> Relations { get; set; } // Bad name but proves point.
    }
    
    TableB
    {
        int IDTableB { get; set; }
        ICollection<TableABC> Relations { get; set; }
    }
    
    TableC
    {
        int IDTableC { get; set; }
        ICollection<TableABC> Relations { get; set; }
    }
    
    TableABC
    {
        int IDTableA { get; set; }
        TableA A { get; set; }
        int IDTableB { get; set; }
        TableA B { get; set; }
        int? IDTableC { get; set; } // Optional
        TableA C { get; set; }
    }
