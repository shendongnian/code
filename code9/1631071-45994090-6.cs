    [Route("api/common/JsonToXml")]
            [AcceptVerbs("POST")]
            public HttpResponseMessage JsonToXml(dynamic data)
            {
                StringBuilder str = new StringBuilder();
    
                str.Append("<Items>");
                for (var ic = 0; ic < data.Items.Count; ic++)
                {
                    str.Append("<element><id>");
                    str.Append(Convert.ToInt32(data.Items[ic].id));
                    str.Append("</id></element>");
                }
    
                str.Append("</Items>");
    
                return Request.CreateResponse(HttpStatusCode.OK, Convert.ToString(str));
            }
