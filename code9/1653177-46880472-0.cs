    Parallel.ForEach(list, k => k.ids.Sort());
    for(int i = 0; i < list.Count; ++i)
    {
        var ki = list[i];
        if (ki.worked) { continue; }
        for(int j = i + 1; j < list.Count; ++j)
        {
            var kj = list[j];
            if(kj.ids.IntersectSorted(ki.ids, Comparer<int>.Default).Skip(5).Any())
            {
                kj.hidden = 1;
                kj.live = 0;
                kj.worked = true;                        
            }
        }
    }
