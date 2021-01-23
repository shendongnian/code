    using System;
    ......
    namespace Project1
    {
        public partial class WebForm1: System.Web.UI.Page
        {
            //create a datasource
            SqlDataSource source = new SqlDataSource();
    
            protected void Page_Load(object sender, EventArgs e)
            {
                //always set some defaults for the sqldatasource
                source.ID = "source1";
                source.ConnectionString = "connectionString";
                source.SelectCommand = "SELECT firstname, dob, DATEDIFF(hour, dob, GETDATE()) / 8766 AS age FROM table ORDER BY age";
    
                if (!IsPostBack)
                {
                    //bind the grid
                    GridView1.DataSource = source;
                    GridView1.DataBind();
                }
            }
    
            protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
            {
                //the new database query, now with where clause
                source.SelectCommand = "SELECT firstname, dob, DATEDIFF(hour, dob, GETDATE()) / 8766 AS age FROM table WHERE (DATEDIFF(hour, dob, GETDATE()) / 8766 BETWEEN @start AND @end) ORDER BY age";
    
                //get the end age from the dropdown and cast as int
                int end = Convert.ToInt32(DropDownList1.SelectedValue);
    
                //get the start int for the filter
                int start = end - 5;
    
                //if the filter is resetted, make sure the query returns all ages
                if (end == 0)
                {
                    start = 0;
                    end = 99;
                }
    
                //replace the parameters in the query
                source.SelectParameters.Add("start", start.ToString());
                source.SelectParameters.Add("end", end.ToString());
    
                //rebind the grid
                GridView1.DataSource = source;
                GridView1.DataBind();
            }
        }
    }
