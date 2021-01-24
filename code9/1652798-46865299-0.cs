    internal void Update(SpecialDay sd)
    {
        using (SalDBContext _db = new SalDBContext())
        {
            var newsd = _db.SpecialDays.FirstOrDefault(p => p.SpecialDayID==sd.SpecialDayID);
            newsd.JanuaryDay = sd.JanuaryDay;
            // ...
            newsd.DecemberDay = sd.DecemberDay;
            // set only the id to reference the object
            newsd.DayTypeId = sd.DayTypeId;
            // newsd.daytype = sd.daytype;
            try
            {
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
