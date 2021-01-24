    List<SelectListItem> items = (from us in db.Users
                                  where us.ApplicationId == "TMS-APP-03" && us.IsActive == 1
                                  orderby us.NamaKaryawan
                                  select new SelectListItem()
                                  {
                                      Text = us.NamaKaryawan,
                                      Value = us.KodeUser
                                      Selected = KdUser.Contains(us.KodeUser)
                                  }).ToList();
