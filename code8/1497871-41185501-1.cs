        [HttpGet]
        public HttpResponseMessage Test([System.Web.Http.ModelBinding.ModelBinder(typeof(TestRequestModelBinder))] TestRequest request)
        {
            // your code
        }
