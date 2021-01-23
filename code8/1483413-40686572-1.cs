     List<SelectListItem> stateList = (from s in hsipcontext.StateDetails
                                                   select new HSIP.Entities.StateDetails
                                                   {
                                                       StateDesc = s.StateDesc,
                                                       StateCode = s.StateCode,
                                                       StateAbbr = s.StateAbbr
                                                   }).ToList();
