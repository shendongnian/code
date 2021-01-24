            protected void ddlInsentiveCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlMainCategory = (DropDownList)gvInsentivePayment.Rows[0].FindControl("ddlInsentiveCategory");
            DropDownList ddlDependentCategory = (DropDownList)gvInsentivePayment.Rows[1].FindControl("ddlInsentiveCategory");
            if (ddlDependentCategory.SelectedIndex == 0)
            {
                ddlMainCategoryValue = Convert.ToInt32(ddlMainCategory.SelectedValue);
                List<SalesStaff> FetchDependentList = // Bind the list using selected value from the 1st dropdown in the first row.
                ddlDependentCategory.DataSourceID = null; //Assigning null to remove the DatasourceID in client side.
                ddlDependentCategory.DataSource = FetchDependentList;
                ddlDependentCategory.DataTextField = "Name";
                ddlDependentCategory.DataValueField = "ID";
                ddlDependentCategory.DataBind();
            }
        }
