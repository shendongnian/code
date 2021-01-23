    public void AddToCartCookie(List<string> listCookie)
    {        
          string objCartListString = string.Join(",", listCookie);
     
          if (Request.Cookies["CartCookie"] == null)
              Response.Cookies["CartCookie"].Value = objCartListString;
          else
              Response.Cookies["CartCookie"].Value = Request.Cookies["CartCookie"].Value + "|" + objCartListString;
  
          Response.Cookies["CartCookie"].Expires = DateTime.Now.AddYears(30);
    }
