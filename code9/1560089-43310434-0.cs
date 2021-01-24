      public class KimlikNoViewmodel
        {
            public string KimlikNo { get; set; }
        }
    
        public ActionResult YeniBelge (string KimlikNo)
        {
            KimlikNoViewmodel viewModel = new KimlikNoViewmodel();
            viewModel.KimlikNo = KimlikNo;
    
            return View(viewModel);
        }
