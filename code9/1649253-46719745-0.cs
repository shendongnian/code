    throw new HttpResponseException(
                        new HttpResponseMessage
                        {
                            StatusCode = HttpStatusCode.InternalServerError,
                            ReasonPhrase = "Internal Server Error",
                            Content = new StringContent(JsonConvert.SerializeObject(myobject))
                        });
