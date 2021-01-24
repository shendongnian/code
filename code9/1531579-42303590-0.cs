       public IActionResult Index()
        {
  
            var kund = DbContext.Kunder.SingleOrDefault(p => p.KundId == 1);
            //byte[] byteArray = DbContext.Kunder.Find(kund).Bild;
            byte[] byteImage = kund.Bild;
            return File(byteImage, "image/jpg");
        }
