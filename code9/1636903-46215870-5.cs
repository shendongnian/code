    public CockpitPersoneel(Graad g)
    {
        if (g = Graad.Steward || g = Graad.Purser)
        {
            throw new Exception("wrong choice");
        }
        else
        {
            this.Graad = g;
        }
    }
