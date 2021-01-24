        public JsonResult GetData()
        {
            var str = "100,140"; // your string
            Model model = new Model();
            //parse string to model
            model.person = str.Split(',').Select(x => new Person { id = Convert.ToInt32(x) });
            //serialize to json
            return Json(model);
        }
