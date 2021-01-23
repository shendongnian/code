     string PageName ="";
          if(Request.QueryString["PageName"] != null)
          {
           PageName= Request.QueryString["PageName"];
          }
     
         
        if(PageName != "")
        {
         string empCustId = Request.QueryString["Customer_No"];
                        if (empCustId.Length != 0)
                        {
                            CustInvoice("empCustId");
                        }
        }
        else{
          bindCustInvoice(objSession.getSession(HttpContext.Current, "NonEmpCode"));
        }
