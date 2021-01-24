    public ActionResult Create()
    {
      var vm = new MyViewModel();
      vm.Cities = GetCities();
      return View(vm);
    }
    private List<SelectListItem> GetCities()
    {
        var options = new List<SelectListItem>();
        var constring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
        using (var c = new SqlConnection(constring))
        {
            using (var cmd = new SqlCommand("select Cityid, Description FROM Cities", c))
            {
                c.Open();
                var rdr = cmd.ExecuteReader();
                options = new List<SelectListItem>();
                while (rdr.Read())
                {
                    var o = new SelectListItem
                    {
                        Value = rdr.GetInt32(rdr.GetOrdinal("Cityid")).ToString(),
                        Text = rdr.GetString(rdr.GetOrdinal("Description"))
                    };
                    options.Add(o);
                }
            }
        }
        return options;
    }
