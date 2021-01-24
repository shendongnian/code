    public ClassNameVM(YourItemType item)
    {
        Name = item.FirstName + " " + item.LastName;
        TimeTotalPFID = lstSummaries.Where(x => x.PFID == item.ID).Sum(x => x.Time);
        TimeTotalPNFID = lstSummaries.Where(x => x.PNFID == item.ID).Sum(x => x.Time);
        TimeTotalVO = lstSummaries.Where(x => x.VO == item.ID).Sum(x => x.Time);
        TotalTime = TimeTotalPFID + TimeTotalPNFID + TimeTotalVO;
    }
