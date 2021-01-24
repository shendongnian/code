    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public Nullable<bool> Isdisplay_ { get; set; }
        public Nullable<int> CatId { get; set; }
        public string CatName { get; set; }
    }
    
    var data = (from t in db.SubCategories
    join ts in db.Categories on t.CatId equals ts.CategoryId 
    select new { a1 = t.SubId, a2 = t.SubImage, a3 = t.SubIsdisplay_, a4 = 
     t.SubName, a5 = ts.CategoryName }).ToList();
            List<SubCategory> p1 = new List<SubCategory();
            foreach (var i in data)
            {
                SubCategory p2 = new SubCategory();
                p2.Id = i.a1;
                p2.Name = i.a4;
                p2.Image = i.a2;
                p2.Isdisplay_ = i.a3;
                p2.CatName = i.a5;
                p1.Add(p2);
            }
            return p1;
