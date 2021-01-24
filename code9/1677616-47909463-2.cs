    var adOld = ctx.AdOld.Select(ao => new Ad { Pk = ao.PK, Text = ao.Text }).ToList();
    var adNew = ctx.AdNew.Where(an => an.IsActive).Select(an => new Ad { Pk = an.PK, Text = an.Text }).ToList();
    var result = adOld.Union(adNew).ToList();
    public class Ad
    {
        public int Pk { get; set; }
        public string Text { get; set; }
    }
