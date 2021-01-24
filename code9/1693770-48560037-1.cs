    if (Request.QueryString["RegNo"] != null) {
	  int num = 0; 
      bool parseResult = Int32.TryParse(Request.QueryString["RegNo"].ToString(), out num);
	  if (parseResult == true) {
        //valid number, so continue
        if (!IsPostBack)
        {
          BindTextBoxvalues();
        }    
      }
	  else {
        //do something suitable here like display an error message or throw an exception, or continue without executing this particular piece of functionality, whatever is necessary for your application
      }
    else {
        //do something suitable here like display an error message or throw an exception, or continue without executing this particular piece of functionality, whatever is necessary for your application
    }
