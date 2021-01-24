    var dictionary = new Dictionary<string, List<ComRep>>();
    if (dt.Rows.Count > 0)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ComRep Info = new ComRep();
            ....
            /// Your object initialization here
            if(!dictionary.ContainsKey(Info.PID))
                dictionary.Add(Info.PID, new List<ComRep>{ Info });
            else
                dictionary[Info.PID].Add(Info);
        }
    }
    retrun dictionary;
