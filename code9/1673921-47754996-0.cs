    public virtual ActionResult yourController(Product prod, HttpPostedFileBase imgUpload)
    {
      Product prod = new Product();
      var imgT = new MemoryStream();
      if(imgUpload!=null){
        imgUpload.InputStream.CopyTo(imgT);
        prod.Image = imgT.ToArray();
      }
    }
