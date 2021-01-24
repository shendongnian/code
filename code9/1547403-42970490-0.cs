        [HttpGet]
        [Auth(Roles = "User")]
        public HttpResponseMessage Get(Guid id, [FromUri]string format = "json")
        {
                Guid userGuid = GetUserID(User as ClaimsPrincipal);                
                
                HttpStatusCode sc = HttpStatusCode.OK;
                string sz = "";
                try
                {
                    sz = SerializationHelper.Serialize(format, SomeDataRepository.GetOptions(id, userGuid));
                }
                catch (Exception ex)
                {
                    sc = HttpStatusCode.InternalServerError;
                    sz = SerializationHelper.Serialize(format,
                                                       new ApiErrorMessage("Error occured",
                                                                           ex.Message));
                }
                var res = CreateResponse(sc);
                res.Content = new StringContent(sz, Encoding.UTF8, string.Format("application/{0}", format));
                return res;            
        }
