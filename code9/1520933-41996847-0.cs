        [HttpPost]
        public ResultObjekt GetResult(FormCollection formCol, FormularData model)
        {
            //Note that here both FormCollection and FormularData are used.
            //To get values from FormCollection use something like below:
            var item1 = formCol.Get("Item1");
        }
