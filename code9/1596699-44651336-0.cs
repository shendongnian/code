      [HttpPost]
            Public async Task<IHttpActionResult> ProcessRequest(string saopRequest)
            {   //here just a bit of string manipulation 
               var index = soapRequest.IndexOf("<ns2:processRequest");
                    var lasindex = soapRequest.IndexOf("</ns2:processRequest>");
                    var length = lasindex - index +"</ns2:processRequest>".Length  ;           
                    var body = soapRequest.Substring(index,length);
                    var request = body.Replace("ns2:", string.Empty).Replace("xmlns:ns2=\"http://b2b.mobilemoney.mtn.zm_v1.0/\"",string.Empty);
                    
                    XDocument xResult = XDocument.Parse(request);
                                
        
                    XmlSerializer deserializer = new XmlSerializer(typeof(ProcessRequest), new XmlRootAttribute("processRequest"));
                    if (xResult.Root != null)
                    {
                        var finalRequest= (ProcessRequest)deserializer.Deserialize(xResult.Root.CreateReader());
                        //do what you  want here 
                    }                
            }
        
        
        
        	[XmlRoot(ElementName="parameter")]
        	public class Parameter {
        		[XmlElement(ElementName="name")]
        		public string Name { get; set; }
        		[XmlElement(ElementName="value")]
        		public string Value { get; set; }
        	}
        
        	[XmlRoot(ElementName="processRequest")]
        	public class ProcessRequest {
        		[XmlElement(ElementName="serviceId")]
        		public string ServiceId { get; set; }
        		[XmlElement(ElementName="parameter")]
        		public List<Parameter> Parameter { get; set; }		
        	}
    }
     
     
    
