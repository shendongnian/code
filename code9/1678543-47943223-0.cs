        [HttpGet("filter")]
        public JsonResult GetCity(int id, string name) {
            if (name == null) return GetCityWithId(id);
            ...
        }
        private JsonResult GetCityWithId(int id) {
            ...
        }
