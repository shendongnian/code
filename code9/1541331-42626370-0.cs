       var res = nt.Aggregate(new List<NamazTimesModel>(), (t, i) =>
                {
                    if (t.Count > 0)
                    {
                        t[t.Count - 1].endTime = i.salahTime;
                    }
                    t.Add(i);
                    return t;
                }
            );
