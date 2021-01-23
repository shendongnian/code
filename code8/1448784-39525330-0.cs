    protected void grdClient_SelectedIndexChanged(object sender, EventArgs e)
    {
         if(grdClient.SelectedValue != null)
         {
             Project ObjProject = new Project();
             int userClientID. = int .Parse(grdClient.SelectedValue.ToString());
             ObjProject.UserClientID = userClientID;
             grdProject.DataSource = ObjProject.GetProjectList();
             grdProject.DataBind();
         }
     }
