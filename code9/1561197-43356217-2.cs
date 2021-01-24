    public int[,] Board { get; }
    public override int GetHashCode()
    {
        return Board.GetHashCode();
    }
