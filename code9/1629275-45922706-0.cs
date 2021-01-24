    public PartialViewResult GemByMonth(int id, string btn)
    {
        if (btn == "bymnthbtn1")
        {
            var birthgembymonth1 = dbcontext.GemStoneByMonths
                .Where(p => p.GemStoneByMonthId == id)
                .Select(q => new GemStoneByMonth
                {
                    GemEng = q.GemEng,
                    GemImage = q.GemImage
                })
                .FirstOrDefault();
    
            return PartialView("_BirthGemByMonthEng", birthgembymonth1);
        }
        return PartialView();
    }
