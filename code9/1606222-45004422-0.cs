     QuizzrEntities conDb = new QuizzrEntities();
     List<OnLoginData> lstOnLogoonData = new List<OnLoginData>();
     string userpassWordHash = string.Empty;
     var queryForAuthentication =from systemObj in conDb.SystemMasters
                             where systemObj.StaffPin == dminLoginInput.StaffPin
                             join admin in conDb.SystemAdminMasters on systemObj.SystemId equals admin.SystemID
                             select new 
                            {
                            PasswordSalt= admin.PasswordSalt,
                            PasswordHash= admin.PasswordHash, 
                            StaffPin= systemObj.StaffPin,
                            UserName= admin.UserName, 
                           SystemID =  admin.SystemID 
                            };
