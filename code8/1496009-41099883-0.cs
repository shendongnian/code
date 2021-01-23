    object IDispatchMessageInspector.AfterReceiveRequest(ref Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
            {
                try
                {
                    var prop = request.Properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
                    var accept = prop.Headers[HttpRequestHeader.AcceptEncoding];
    
                    if (!string.IsNullOrEmpty(accept) && accept.Contains("gzip"))
                    {
                        var item = new DoCompressExtension();
                        OperationContext.Current.Extensions.Add(item);
                    }
                }
                catch { }
    
                return null;
            }
    void IDispatchMessageInspector.BeforeSendReply(ref Message reply, object correlationState)
            {
                if (OperationContext.Current.Extensions.OfType<DoCompressExtension>().Count() > 0)
                {
                    HttpResponseMessageProperty httpResponseProperty = new HttpResponseMessageProperty();
                    httpResponseProperty.Headers.Add(HttpResponseHeader.ContentEncoding, "gzip");
                    reply.Properties[HttpResponseMessageProperty.Name] = httpResponseProperty;                                
                }            
            }
