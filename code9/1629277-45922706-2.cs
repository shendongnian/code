    public PartialViewResult GemByMonth(int id, string btn)
    {
        if (btn == "bymnthbtn1")
        {
            var entity = dbcontext.GemStoneByMonths
                .FirstOrDefault(p => p.GemStoneByMonthId == id);
    
            var birthgembymonth1 = new GemStoneByMonth
            {
                GemEng = entity.GemEng,
                GemImage = entity.GemImage
            };    
            return PartialView("_BirthGemByMonthEng", birthgembymonth1);
        }
        return PartialView();
    }
