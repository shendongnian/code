            public static List<FinalProduct> lstproductname = new 
            List<FinalProduct>();
            var partialResult = db.Company.OrderBy(x => x.id).Take(1);
            var finalResult = (from j in db.productListDbSet
                               join comp in partialResult
                               on j.mstr_company_id equals comp.id
                               select new FinalProduct {id= j.id,name= j.name }).OrderBy(x => x.name).ToList();
            lstproductname = finalResult.Cast<FinalProduct>().ToList();
            foreach (var d in lstproductname.ToList())
            {
                String id = d.id.ToString();
                String name = d.name.ToString();
            }
