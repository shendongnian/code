    WebResponse response;
    try {
       response = request.GetResponse();
    }
    catch(WebException e) {
       if(e.Message.Contains("302")
          response = e.Result;
    }
 
