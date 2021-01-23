    public override string ToString()
    {
        return String.Join(Environment.NewLine,
            mTable.Select((s,i)=>new {Index=i, s.Key, s.Value, s.Status})
                  .Where(w => w.Status == EntryType.Active)
                  .Select(s => $"[{s.Index}]Key:{s.Key}=Value:{s.Value}")
            );
    }
