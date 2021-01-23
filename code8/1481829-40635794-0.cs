    private DataTable PopulateDropdown(string connectionString, DataTable datatable, string query, System.Web.UI.WebControls.DropDownList yourDropdownList)
        { 
           SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(dt);
            yourDropdownList.DataSource = dt;
            yourDropdownList.DataBind();
            return dt;
        
        }
