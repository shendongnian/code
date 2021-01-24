    DateTime d = DateTime.Now;
        var monthBefore = d.AddMonths(-1);
        var list =
            _db.PlayHistories
            .OrderByDescending(x=>x.SoundRecordingId)
            .Where(t => t.DateTime >= monthBefore)
            .GroupBy(x=>x.SoundRecordingId, (key,values) => new {SoundRecordingID=key, High=values.count()})
            .Take(20)
            .ToList();
