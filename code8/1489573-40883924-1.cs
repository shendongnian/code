            for (int i = 0; i < 100; i++)
            {
                if (elo.ReadObjMask(i) > 0)
                {
                    // Create a new listin here
                    eigenschaften = new List<string>();
    
                    var iRet = elo.PrepareObjectEx(0, 0, i);
                    maskenname = elo.ObjMName();
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
                    else
                    {
                        // Do nothing
                    }
                    EloMask emask = new EloMask(maskenname, eigenschaften);
                    staticVariables.allMask.Add(emask);
                }
            }
