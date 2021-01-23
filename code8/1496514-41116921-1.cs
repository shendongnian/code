    public static SelectList GetDropDown()
        {
            using (var db = new DAL.JurisprudenceDBEntities())
            {
                var query = db.Lawyers.Select(o => new { o.LawyerID, o.Name, ... } );
                return new SelectList(query.OrderBy(o => o.Name).ToList(), "LawyerID", "Name");
            }
        }
