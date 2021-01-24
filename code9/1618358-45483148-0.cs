      [AllowAnonymous]
        public JsonResult GetCitiesByDistrict(int id)
        {
            List<SelectListItem> cities = new List<SelectListItem>();
           
            var city = new List<City>();
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                city = context.Cities.Where(e => e.DistrictId == id).ToList();
            }
            return Json(new SelectList(city, "Id", "Name"), JsonRequestBehavior.AllowGet);
        }
