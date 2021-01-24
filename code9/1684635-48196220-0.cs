    public JsonResult Search(string pr) {
        var s = _context.Products.Where(a => a.Name.Contains(pr) || a.Model.Contains(pr) || a.Brands.Name.Contains(pr)).Take(10).Select(a => new {
            resultItem = a.Name + " " + a.Model + " " + a.Brands.Name
        }).ToList();
    	
        var storen = _context.Stores.Where(a => a.Name.StartsWith(pr)).Select(a => new {
            resultItem = a.Name
        }).ToList();
    	
    	var returnList = s.Concat(storen).ToList();
    	
        return Json(new {
            returnList
        }, JsonRequestBehavior.AllowGet);
    }
