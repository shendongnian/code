    public override bool Equals(object obj)
    {
        SimulationResult simResult = obj as SimulationResult;
        if (simResult != null)
        {
            if (Winner == simResult.Winner
                && Second == simResult.Second
                && Third == simResult.Third
                && Fourth == simResult.Fourth)
            {
                return true;
            }
        }
        return false;
    }
    public override int GetHashCode()
    {
        int hash = 12;
        hash = hash * 5 + Winner.GetHashCode();
        hash = hash * 5 + Second.GetHashCode();
        hash = hash * 5 + Third.GetHashCode();
        hash = hash * 5 + Fourth.GetHashCode();
        return hash;
    }
