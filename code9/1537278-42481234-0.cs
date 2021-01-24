      Product objProduct = new Product();
      objProduct.id = "1";
      objProduct.name = "Sana";
      string json = JsonConvert.SerializeObject(objProduct);
      var baseAddress = "http://..................";
      var respond = "";
      //Post request 
      using (WebClient wc = new WebClient())
      {
        wc.Encoding = Encoding.UTF8;
        respond =  wc.UploadString(baseAddress, json);
      }
