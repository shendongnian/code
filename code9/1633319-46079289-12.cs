    public void Add(BaseInterface u, int id)
    {
         ((IChangeID)u).SetID(id);
         Units.Add(u);
    }  
