    List<Errorlog> lst = new List<Errorlog>(); // create list 
    // loop and add items to above list as below
    foreach (int k in id)
    {
        DynamicParameters param = new DynamicParameters();
        param.Add("SiteId",k, DbType.Int16);
        List<Errorlog> temp= con.Query<Errorlog>("Usp_Temp", param, null, true, 200, CommandType.StoredProcedure).ToList();
        //add to main list
        lst .AddRange(temp);
    
    }
    //finally show all the data
    if (lst.Count != 0)
    {
        grd.DataSource = lst; 
        grd.DataBind();
    }
