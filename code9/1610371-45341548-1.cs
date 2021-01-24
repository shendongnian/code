        public class Age
        {
            public int amount { get; set; }
            public string unit { get; set; }
        }
        public class RequestParameter
        {
            public Age age { get; set; }
        }
        public class RequestBody
        {            
            public RequestParameter parameters { get; set; }
        }
        [HttpPost]
        public ActionResult GetValue(RequestBody result)
        {
            var age = result.parameters.age.amount;
            ...
        
