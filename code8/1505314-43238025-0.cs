MWS.MyWebServiceSoapClient webService = new MWS.MyWebServiceSoapClient();
webService.Open();
string someDataYouWant = webService.SomeMethodToGetData();
webService.Close();
    Or you can probably do:
MyWebService webService = new MyWebService();
string someDataYouWant = webService.SomeMethodToGetData();
webService.Dispose();
