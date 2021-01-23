    public object GetPromotionReport()
        {
            List<PromotionHistorywithNames> finalData;
            finalData = (from st in db.PromotionHistories
                         select new PromotionHistorywithNames
                         {
                             PromotionID = st.PromotionID,
                             EmployeeID = st.EmployeeID,
                             PreviousPost = (from dd in db.Designations where dd.DesignationID == st.Promotion select dd.DesignationName).FirstOrDefault(),
                             CurrentPost = (from dd in db.Designations where dd.DesignationID == st.currentD select dd.DesignationName).FirstOrDefault()
                         }).ToList();
            return finalData;
        }
