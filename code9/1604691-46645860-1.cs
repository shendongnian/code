    public string PerformSyncSoapServiceRequest(string requestXML)
    		{
    			var ServiceResult = string.Empty;
    			try
    			{
    				HttpWebRequest request = CreateSOAPWebRequest();
    				XmlDocument SOAPReqBody = createSOAPReqBody(requestXML);
    				using (Stream stream = request.GetRequestStream())
    				{
    					SOAPReqBody.Save(stream);
    				}
                    using (WebResponse Serviceres = request.GetResponse())
    				{
    					using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
    					{
    						ServiceResult = rd.ReadToEnd();
    					}
    				}
    
    			}
    			catch (Exception e)
    			{
    				throw;
    			}
    			return ServiceResult;
    		}
    public HttpWebRequest CreateSOAPWebRequest()
    		{
    			HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(@"your_URL");
    			Req.Headers.Add(@"SOAP:Action");
    			Req.ContentType = "text/xml;charset=\"utf-8\"";
    			Req.Accept = "text/xml";
    			Req.Method = "POST";
                Req.Timeout = 20000;
                Req.ReadWriteTimeout = 20000;
                return Req;
    		}
    
    		XmlDocument createSOAPReqBody(string requestXML)
    		{
    			XmlDocument SOAPReqBody = new XmlDocument();
    			SOAPReqBody.LoadXml(requestXML);
    			return SOAPReqBody;
    		}
