    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable dt;
        //check if the datatable already exists in the viewstate, if not create a new datatable
        if (ViewState["myTable"] == null)
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Name", typeof(string)), new DataColumn("Age", typeof(decimal)) });
        }
        else
        {
            //correct viewstate exists, cast back to a datatable
            dt = ViewState["myTable"] as DataTable;
        }
        //add the new values
        dt.Rows.Add(TextBox1.Text, Convert.ToDecimal(TextBox2.Text));
        //bind the datatable to the gridview
        GridView1.DataSource = dt;
        GridView1.DataBind();
        //save the datatable into the viewstate
        ViewState["myTable"] = dt;
        //clear the textboxes
        TextBox1.Text = "";
        TextBox2.Text = "";
    }
