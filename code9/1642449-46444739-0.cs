         public JsonResult GetSearchValue(string search,int? gvt)
        {         
            List<VilleModels> allsearch = new List<VilleModels>();        
            allsearch = db.Villes.Where(x => x.VilleName.Contains(search)).AsEnumerable().ToList();
            var localities = allsearch.Where(i=>i.IdGouvernorat == gvt).Select(x => new VilleModels { IdVille = x.IdVille, VilleName = x.VilleName }).ToList();
            return new JsonResult { Data = localities, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
