        [HttpPost]
        public JsonResult<MyCustomClass> Details(RequestClass request)
        {
            var encoding = Encoding.GetEncoding("iso-8859-1");
            var settings = new Newtonsoft.Json.JsonSerializerSettings()
            {
                ContractResolver = new MyCustomResolver()
            };
            return Json(_InputService.CustomClassGet(request.Id), settings, encoding);
        }
