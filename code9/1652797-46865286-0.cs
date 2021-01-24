    internal void Update(SpecialDay sd)
    {
        using (SalDBContext _db = new SalDBContext())
        {
            var newsd = _db.SpecialDays.Find(p => p.SpecialDayID==sd.SpecialDayID);
            newsd.JanuaryDay = sd.JanuaryDay;
            ....
            newsd.DecemberDay = sd.DecemberDay;
            newsd.DayTypeId = sd.DayTypeId;
            // newsd.daytype = sd.daytype; Must be eliminated!
            try
            {
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
