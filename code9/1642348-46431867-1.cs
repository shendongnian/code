    IQueryable<gbd_Pages> Listpagespages = _db.gbp_Pages
                                              .Any(p => p.PrimaryKeyID == (from c in _db.gbd_Content
                                                                           where c.IsActive == true 
                                                                              && c.IsDeleted == false 
                                                                           select c.gbd_Pages.PrimaryKeyID)
                                                                          .FirstOrDefault())
                                              .Select(p => new 
                                                      {
                                                          // select specific fields here...
                                                          p,
                                                          SortCol = _db.gbp_Content
                                                                       .FirstOrDefault(c => c.PrimaryKeyID)
                                                                       .Where(c => c.IsActive == true && c.IsDeleted == false &&
                                                                              c.gbd_Template_Fields.SortOrder == sortOrder)
                                                                       .Select(c => c.Content)
                                                      })
                                              .OrderBy(v => c.SortCol);
