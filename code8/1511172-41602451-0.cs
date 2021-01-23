    from a in db.TableA
    join b in db.TableB on a.TableAId equals b.TableAId into c
    from d in c.DefaultIfEmpty()
    group b by a into g
    select new
    {
        TableAId = g.Key.TableAId,
        value = g.Key.value,
        value2 = g.Key.value2,
        successCount = g.Count(t => t.Status == "success"),
        errorCount = g.Count(t => t.Status == "failed")
    }
