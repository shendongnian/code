            public DomainUser FindUserBySecurityIdentifier(SecurityIdentifier securityIdentifier)
        {
            var domainUser = new DomainUser(securityIdentifier.ToString());
            string domainUserJson = Newtonsoft.Json.JsonConvert.SerializeObject(domainUser);
            HttpContent content = new StringContent(domainUserJson);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            Exception exception = null;
            var item = DomainUser.EMPTY;
            var endpointUrl = ConstructEndpointUrl("api/FindUserBySecurityIdentifier");
            if (!string.IsNullOrWhiteSpace(endpointUrl))
            {
                Task postLink = HttpClient.PostAsync(endpointUrl, content).ContinueWith(task =>
                {
                    if (task.Status == TaskStatus.RanToCompletion)
                    {
                        var response = task.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            // after I read the result into a string first and deserialized it with JsonConvert.DeserializeObject it worked
                            var objectAsString = response.Content.ReadAsStringAsync().Result;
                            item = JsonConvert.DeserializeObject<DomainUser>(objectAsString);
                        }
                        else
                        {
                            exception = new Exception(response.ToString());
                        }
                    }
                    else
                    {
                        exception = new Exception("The http request to the server did not run to completion. Please contact the administrator");
                    }
                });
                postLink.Wait();
            }
            if (exception != null)
            {
                throw exception;
            }
            return item;
        }
