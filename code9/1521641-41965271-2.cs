    public void KillRandom()
    {
        InnerVar.r = null;
    }
    
    public int UseVar()
    {
        return InnerVar.r.Next();
    }
