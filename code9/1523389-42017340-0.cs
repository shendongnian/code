    var dictionary = new Dictionary<string, ComRep>();
    if (dt.Rows.Count > 0)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ComRep Info = new ComRep();
            Info.PID = dt.Rows[i]["PID"].ToString();
            Info.PName = dt.Rows[i]["PName"].ToString();
            Info.PDesc = dt.Rows[i]["PDesc"].ToString();
            Info.commitmentid = dt.Rows[i]["commitmentid"].ToString();
            Info.country = dt.Rows[i]["country"].ToString();
            Info.status = dt.Rows[i]["status"].ToString();
            Info.Count = x;
            dictionary .Add(Info.PID, Info);
        }
    }
    retrun dictionary;
