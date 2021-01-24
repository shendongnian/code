    public void RegisterNewUser(IDCRegisterViewModel model)
    {
        string fullAddress = model.AddressLine1 + "\n" + model.AddressLine2 + (string.IsNullOrEmpty(model.AddressLine2) ? "" : "\n" ) + model.City + ", " + model.State + " " + model.Zip + "\n" + model.Country; 
        using (var AuthContext = new InfoKeeperEntities1())
        {
            AuthContext.Locations.Add(new Location {
                Line1 = model.AddressLine1,
                Line2 = model.AddressLine2,
                City = model.City,
                State = model.State,
                Zip = model.Zip,
                Country = model.Country,
                UserID = model.UserID,
                FullAddr = fullAddress
            });
            AuthContext.ProfileDatas.Add(new ProfileData
            {
                UserID = model.UserID,
                UACC = model.UACC,
                isRecCenter = model.IsRecCenter,
                isCustAdmin = model.IsCustAdmin
            });
            //Add to bridge tables for user/dept and group/dept
            List<Department> deptList = new List<Department>();
            foreach (var ID in model.GroupIDs)
            {
                deptList.Add(AuthContext.Departments.FirstOrDefault(x => x.ID == ID));
            }
            var user = AuthContext.AspNetUsers.Include("Departments").FirstOrDefault(x => x.Id == model.UserID);
            
            foreach (var department in deptList)
            {
                user.Departments.Add(department);
                foreach (var groupID in model.GroupIDs)
                {
                    var group = AuthContext.Groups.Include("Departments").FirstOrDefault(x => x.ID == groupID);
                    group.Departments.Add(department);
                }
            }
        }
    }
