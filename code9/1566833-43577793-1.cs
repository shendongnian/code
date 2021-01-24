    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.SqlClient;
    using System.Data;
    namespace Homemade01
    {
    public partial class WebForm1 : System.Web.UI.Page
    {
        //int rowCount;
        protected void Page_Load(object sender, EventArgs e)
        {
      
        }
        protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            //int rowCount = e.AffectedRows;
        }
        protected void SqlDataSource2_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            int rowCount = e.AffectedRows; 
            //Above find the affected rows in SQL Data Source 2 and counts them then assigns them to an INT
            Label1.Text = "The number of Books found is: " + rowCount.ToString();
            //Label prints its text plus the rowCount variable which is converted to a string
        }
               
        }
       }
