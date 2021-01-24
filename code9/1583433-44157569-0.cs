    Public class problem()
    {
    public int id;
    public string description;
    public short type;
    }
    
    .DefaultIfEmpty(
        new problem()
        {
            Id = ticketsId,
            Description = string.empty,
        });
