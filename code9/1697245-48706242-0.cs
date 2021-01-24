    var result =
                        from i in dc.TFFiles                    
                        where i.Tid == tid                    
                        group i by new { i.Title, i.Type } into gr
                        join c in dc.FCategories on gr.FirstOrDefault().CatId equals c.Id
                        select new { id = gr.FirstOrDefault().id, Title = gr.FirstOrDefault().Title, Version = (from cv in gr select cv.Version).Max() };
