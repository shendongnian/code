    public ActionResult AddOffer()
    {
       var vm = new AddOfferAnnounceModel();
       vm.Items = GetItems();
       return View(vm);
    }
    public List<SelectListItem> GetItems()
    {
        var list = new List<SelectListItem>();
        var sql = "select TypeId, TypeDesc from announceTypes where parentTypeId = 1";
        var conStr = @"yourConnectionStringGoesHere";
        using (var c = new SqlConnection(conStr))
        {
            using (var cmd = new SqlCommand(sql, c))
            {
                c.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (r.HasRows)
                    {
                        while (r.Read())
                        {
                            var t = new SelectListItem()
                            {
                                Value = r.GetInt32(r.GetOrdinal("TypeId")).ToString(),
                                Text = r.GetString(r.GetOrdinal("TypeDesc"))
                            };
                            list.Add(t);
                        }
                    }
                }
            }
        }
        return list;
    }
