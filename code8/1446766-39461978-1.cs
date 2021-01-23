    for (int i = 0; i < DG.Count; i++)
    {
        if (!dependants.ContainsKey(DG[i].Item1)) 
        {
            List<string> temp = new List<string>();
            temp.add(DG[i].Item2); 
            dependants.Add(DG[i].Item1, temp);
        }
        else
            dependants[DG[i].Item1].Add(DG[i].Item2);
    }
