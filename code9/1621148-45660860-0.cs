    using(var con = new SqlConnection(GetConnectionString()))
    {
        con.Open();
        using(var trans = con.BeginTransaction())
        {
        bool IsSave = false;
        for(int i = 0; i < obj.Count; i++) 
        {
            IsSave = Some_Insert_Method_On_Other_Class(obj[i], con, trans);
            if (!IsSave)
            {
                trans.Rollback();
                return;
            }
        }
        trans.Commit();
        }
    }
