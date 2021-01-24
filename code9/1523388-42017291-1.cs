    Dictionary<string,ComRep> ComRepDict = new Dictionary<string,ComRep>();
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        if(!ComRepDict.ContainsKey(dt.Rows[i]["PID"].ToString())
        {
          ComRepDict.Add( dt.Rows[i]["PID"].ToString(), new ComRep(){
                          PID = dt.Rows[i]["PID"].ToString();
                          PName = dt.Rows[i]["PName"].ToString();
                          PDesc = dt.Rows[i]["PDesc"].ToString();
                          commitmentid = dt.Rows[i]["commitmentid"].ToString();
                          country = dt.Rows[i]["country"].ToString();
                          status = dt.Rows[i]["status"].ToString();
                         Count = x;
                       });
    }
