     protected void GridView1_DataBound1(object sender, EventArgs e)
            {
                //GridViewRow row = GridView1.FooterRow;
        
                //var CName = ((DropDownList)row.Cells[1].FindControl("ddlCName")).SelectedValue;
                //var s = CName;
        
                DropDownList ddlCName = GridView1.FooterRow.FindControl("ddlCName") as DropDownList;
                ddlCName.DataSource = GetData("SELECT * FROM TBCourse  INNER JOIN TbCourseMajor ON  TBCourse.CId = TbCourseMajor.CId ");
                ddlCName.DataTextField = "CName";
                ddlCName.DataValueField = "CId";
                ddlCName.DataBind();
        
                //Add Default Item in the DropDownList
                ddlCName.Items.Insert(0, new ListItem("Please select"));
            }
