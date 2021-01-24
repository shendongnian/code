    public List<RequiredValues> GetCasedetails(string userName)
     { 
           RequiredValues values = new RequiredValues();
           DropDownListvalues requiredList = new DropDownListvalues();
           requiredList = setDropDownListValues("exec sp_Search_GetHISA");
           using (var cases = new Entities())
           {
                System.Guid userId = (from list in cases.aspnet_Membership
                                          where list.Email == userName
                                          select list.UserId).FirstOrDefault();
                values.UserType= "Admin";
                string coder = (from list in cases.Accidents
                                    join users in cases.aspnet_Users on userId equals users.UserId
                                    where userName == list.coder
                                    select list.coder).FirstOrDefault();
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter("UserId", userId));
                values.CaseDetails = cases.Database.SqlQuery<CaseValues>("exec sp_CaseSearch @UserId", sqlParams.ToArray()).ToList();
            }
            return values;
