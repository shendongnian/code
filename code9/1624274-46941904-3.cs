        [HttpPost]
        public ActionResult GetCOFData(MyFormServerSideViewModel  viewModel)
        {
          ...
          ...
          ...
              viewModel.prop1 = "aaa",
              viewModel.prop2 = "bbb"
              return Json(response, JsonRequestBehavior.AllowGet);
        }
