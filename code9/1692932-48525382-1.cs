    public List<Entitys.Member> GetALLMembers()
    {            
        List<Models.EF_Model.Member> list = new Models.CRUD.Member().Get_AllMemeberRecords();
        if (list != null)
            return list.Select(l => new Entitys.Member()).ToList();
        else
            return new List<Entitys.Member>();
    }
