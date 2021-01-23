    if (elo.ReadObjMask(i) > 0)
    {
        var iRet = elo.PrepareObjectEx(0, 0, i);
        maskenname = elo.ObjMName();
        // create a new list here!!!
        var eigenschaften = new List<string>();
        if (maskenname != "")
        {
            for (int e = 0; e < 50; e++)
            {
                string eigenschaft = elo.GetObjAttribName(e);
                if (eigenschaft != "" && eigenschaft != "-")
                {
                    eigenschaften.Add(eigenschaft);
                }
            }
            
            allMasks.Add(maskenname);
        }
        EloMask emask = new EloMask(maskenname, eigenschaften);
        staticVariables.allMask.Add(emask);
        // clearing the list is no longer needed                   
    }
