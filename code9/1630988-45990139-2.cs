        public ActionResult Index()
        {            
            string[] values = (ConfigurationManager.AppSettings["DropdownValues"]).Split(',').Select(sValue => sValue.Trim()).ToArray();
            List<SelectListItem> dropDowns = new List<SelectListItem>();
            for (int i = 0; i < values.Length; i++)
            {
                dropDowns.Add(new SelectListItem { Text = values[i], Value = values[i] });
            }
            ViewBag.DropdownVals = dropDowns;
            return View();
        }
