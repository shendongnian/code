    public IEnumerable<Market_Masters> GetMaster()
    {
        var x = from n in db.Masters
                join chil in db.ChildMasterMasters on n.MasterId equals chil.MasterId into t
                select new Market_Masters()
                    {
                        MasterId = n.MasterId,
                        Prod_Name = n.Prod_Name,
                        Produ_Adress = n.Produ_Adress,
                        Price = n.Price,
                        Hello = t
                    };
        return x.ToList();
    }
