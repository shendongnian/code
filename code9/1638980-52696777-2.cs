      SoapEnvelope responseEnvelope = null;
            using (var client = SoapClient.Prepare().WithHandler(new DelegatingSoapHandler()
            {
                OnHttpRequestAsyncAction = async (z, x, y) =>
                {
                    x.Request.Content = new StringContent(xml , Encoding.UTF8, "text/xml");
                }
            }))
            {
                    responseEnvelope = client.SendAsync("url", "action",SoapEnvelope.Prepare()).Result;
            }
