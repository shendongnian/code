    protected void LoadFromEntity_Click(object sender, EventArgs e)
            {
                using (UserEntites ObjUserEntities = new UserEntites())
                {
                    DataList1.DataSource = ObjUserEntities.UserMasters.ToList();
                    DataList1.DataBind();
                }
            }
    
            protected void LoatFromStoredProcedure_Click(object sender, EventArgs e)
            {
                using (UserEntites ObjUserEntities = new UserEntites())
                {
                    List<USP_FetchUserDetails_Result> OBjUserDetails = new List<USP_FetchUserDetails_Result>();
                    OBjUserDetails = ObjUserEntities.USP_FetchUserDetails().ToList();
                    DataList1.DataSource = OBjUserDetails;
                    DataList1.DataBind();
                }
            }
