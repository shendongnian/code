                  Uri resourceAddress;
                if (!Helpers.TryGetUri(Host + Port + "/XXX/YYY/directory", out resourceAddress))
                {
                    return;
                }
                IHttpContent jsonContentCoordinates = new HttpJsonContent(JsonValue.Parse("{\"zzz\": \"" + something
                                                                                  + "\", \"xxx\": \"" + somethingXXX
                                                                                  + "\",\"yyy\": \"" + somethingYYY
                                                                                  + "\" }"));
                HttpResponseMessage httpResponseCoordinates = new HttpResponseMessage();
                string httpResponseBodyCoordinates = "";
                try
                {
                    httpResponseCoordinates = await httpClient.PostAsync(resourceAddress, jsonContentCoordinates).AsTask(cts.Token);
                    httpResponseBodyCoordinates = await httpResponseCoordinates.Content.ReadAsStringAsync();
                    httpResponseCoordinates.EnsureSuccessStatusCode();
                    FlagInternetNotConnected = false;
                    
                }
                catch (Exception)
                {
                 //Catch it if it fails.
                    
                } 
