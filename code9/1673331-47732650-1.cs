        public ActionResult RenderCarScreen(string carJson)
        {
            Car car = Newtonsoft.Json.JsonConvert.DeserializeObject<Car>(carJson);
            return PartialView("CarScreen", car);
        }
