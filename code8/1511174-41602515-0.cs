    from a in db.TableA
    join b in db.TableB on a.TableAId equals b.TableAId into ab
    select new {
        a.TableAId,
        a.value,
        a.value2,
        successCount = ab?.Count(t => t.Status == "success") ?? 0,
        errorCount = ab?.Count(t => t.Status == "failed") ?? 0
    };
