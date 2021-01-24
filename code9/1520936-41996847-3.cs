        [HttpPost]
        public ResultObjekt GetResult(FormularData model)
        {
            //To get values from Form use something like below:
            var formData = Request.Form;
            var item1 = formData.Get("Item1");
        }
