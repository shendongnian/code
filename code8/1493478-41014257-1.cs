        [HttpPost]
        public JsonResult getCityJson(string stateId, string selectCityId = null)
        {
            return Json(getCity(stateId, selectCityId));
        }
        public SelectList getCity(string stateId, string selectCityId = null)
        {
            IEnumerable<SelectListItem> cityList = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(stateId))
            {
                int _stateId = Convert.ToInt32(stateId);
                cityList = (from m in db.Cities where m.StateID == _stateId select m).AsEnumerable().Select(m => new SelectListItem() { Text = m.CityName, Value = m.CityID.ToString() });
            }
            return new SelectList(cityList, "Value", "Text", selectCityId);
        }
