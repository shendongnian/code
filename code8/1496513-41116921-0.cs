    public static SelectList GetDropDown()
        {
            using (var db = new DAL.JurisprudenceDBEntities())
            {
                var query = db.Lawyers.Select(o => new { /*Your atributes*/ } );
                return new SelectList(query.ToList());
            }
        }
