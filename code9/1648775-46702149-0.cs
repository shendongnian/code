    var pageMasters = listOfPages.GroupBy(page=>page.PageName)
                                 .Select(gr=>new PageMaster
                                 { 
                                     AppName = gr.Key,
                                     Pages = gr.Select(p=>p).ToArray()
                                 })
                                 .ToList();
