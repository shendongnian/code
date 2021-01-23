       var r = new ApiResult
                {
                    status = "0",
                    message = new Account()
                    {
                        status = "0",
                        CreationDate = DateTime.Now,
                        Email = "foo@foo.com",
                        FirstName = "Trump",
                        ID = 1,
                        LastName = "Fck",
                        Password = "111",
                        RoleID = 1,
                        doorCode = 222
                    }
                };
    var jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(r);
    
    var apiObject = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResult>(jsonResult);
