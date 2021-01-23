    //return ObjectContext.ScannerStatusHistories.Where(t => t.DetectorID == detectorID).OrderByDescending(d => d.TimeStamp).Take(1);
        var lastRow = ObjectContext.ScannerStatusHistories.Where(t => t.DetectorID == detectorID).OrderByDescending(d => d.TimeStamp).FirstOrDefault();
    //Get last changed row
        if (lastRow != null)
        {
            var lastChangeRow = ObjectContext.ScannerStatusHistories
            .Where(t => t.DetectorID == detectorID
                    && (t.HBD1 != lastRow.HBD1 || t.HBD2 != lastRow.HBD2 || t.HWD1 != lastRow.HWD1 || t.HWD2 != lastRow.HWD2 || t.RC1 != lastRow.RC1 || t.RC2 != lastRow.RC2 || t.RC3 != lastRow.RC3 || t.RC4 != lastRow.RC4))
                .OrderByDescending(d => d.TimeStamp)
                .FirstOrDefault();
        //Return next row
            if (lastChangeRow != null)
            {
                return ObjectContext.ScannerStatusHistories
                .Where(x => lastChangeRow.TimeStamp < x.TimeStamp
                    && x.DetectorID == detectorID)
                .OrderBy(d => d.TimeStamp)
                .Take(1);
            }
        }
    return ObjectContext.ScannerStatusHistories.Where(t => t.DetectorID == detectorID).OrderBy(d => d.TimeStamp).Take(1);
