    private void txt_search_TextChanged(object sender, EventArgs e)
    {
        int columnIndx = dgv_prs_add.CurrentCell.ColumnIndex;
        string columnName = dgv_prs_add.Columns[columnIndx].Name;
        lblPath.Text = columnIndx.ToString() + columnName.ToString();
        
        //Assuming that class name is "PersonInfo".
        Func<PersonInfo, bool> criteria;
        var searchString = txt_search.Text;
        //Assuming that columns are "FirstName", "LastName" and "Address".
        switch (columnName)
        {
            case "FirstName":
                criteria = person=> person.FirstName.Contains(searchString);
                break;
            case "LastName":
                criteria = person=> person.LastName.Contains(searchString);
                break;
            case "Address":
                criteria = person=> person.Address.Contains(searchString);
                break;
            default:
                criteria = person=> true;
                break;
        }
        var query = db.tbl_PrsInfos.Where(criteria).ToList();
        dgv_prs_add.DataSource = query;
    }
