    public void Add(BaseInterface u, int id)
    {
        switch(u)
        {
            case Implementation1 u1:
                u1.ID = id;
                break;
            case Implementation2 u1:
                u1.ID = id;
                break;    
            default :
                throw new ArgumentException("Unexpected implementation!");
        }
        Units.Add(u);     
    }  
