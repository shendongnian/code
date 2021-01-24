              IQueryable<gbd_Pages> Listpagespages = _db.gbd_Content
                                                    .Select (c=>new { c.gbd_Pages })
                                                    .Where(c=>c.IsActive == true && c.IsDeleted == false &&c.gbd_Template_Fields.SortOrder == sortOrder)
                                                    .Distinct()
                                                    .OrderBy(c => c.Content)
                                                    .Select(c => c.gbd_Pages)
