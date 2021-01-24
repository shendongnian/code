         queryResults.Where(q => q.Collected != null).OrderBy(d => d.Collected).ToList()
        .foreach(s => {
        collectedBytes = collectedBytes + s.CollectedSize;
        obj.Collected.Add(new ProductionDataOverTimeVM{
        x =BasicHelpers.FromUTCDate(s.Collected, parms.Offset).Value.ToString("dd/M/yyyy"),
        y=collectedBytes
        })});
    queryResults.Where(q => q.Staged != null).OrderBy(d => d.Staged ).ToList().foreach(s => {
        Staged = Staged + s.Staged ;
        obj.Collected.Add(new ProductionDataOverTimeVM{
        x =BasicHelpers.FromUTCDate(s.Staged , parms.Offset).Value.ToString("dd/M/yyyy"),
        y=Staged 
        })});
