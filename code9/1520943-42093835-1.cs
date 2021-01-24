        [HttpPost]
        [ActionName("GetResult")]
        public ResultObjekt GetResult([FromBody]FormularData values)
        {
            var dictionary = values.ConvertToDictionary();
        }
