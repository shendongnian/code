    public IEnumerable<UnitPhaseLog> GetAllForUnitPhase(long unitPhaseId)
    {
        using (var db = new DbContext(_connStringKey))
        {
            var querys = from s in db.UnitPhaseLogs where s.UnitPhaseId == unitPhaseId select s;
            List<UnitPhaseLog> UnitPhaseLogList = new List<UnitPhaseLog>();
            if (null == querys) return UnitPhaseLogList;
            return querys;
        }
    }
