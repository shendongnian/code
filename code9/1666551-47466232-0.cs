    [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static List<Group> getSubgroups(string Id)
        {
            DataTable dt = new DataTable();
            List<Group> objDept = new List<Group>();
            GroupsRepository jg = new GroupsRepository();
            //Page page = (Page)HttpContext.Current.Handler;
            //DropDownList DDLGroups = (DropDownList)page.FindControl("DDLGroups");
    
            dt = jg.LoadSubGroup(Id.ToInt()); // Here You have convert string to Int that's why you got 500 Error.
                                              
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objDept.Add(new Group
                    {
                        GroupID = Convert.ToInt32(dt.Rows[i][0]),
                        Title = dt.Rows[i][1].ToString(),
                    });
                }
            }
            return objDept;
        }
    
    
      
