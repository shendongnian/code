    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace StackOverflow_Solve.Others
    {
        public partial class GridView : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    grdvShowUsers.DataSource = GetData();
                    grdvShowUsers.DataBind();
                }
            }
    
            private DataTable GetData()
            {
                DataTable dt=new DataTable();
                String connectionString = ConfigurationManager.ConnectionStrings["WaltonCrmConnectionString"].ConnectionString; ;
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
    
                    string servicePointListQuery = String.Format(@"select UserID,UserName from Users ");
                    var command = new SqlCommand(servicePointListQuery, conn);
    
                    SqlDataAdapter dataAdapter=new SqlDataAdapter(command);
                    dataAdapter.Fill(dt);
                }
    
                return dt;
            }
            protected void grdvShowUsers_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.Cells[0].Text == "11614")
                    {
                        Button btnHidden = e.Row.FindControl("btnHidden") as Button;
                        if (btnHidden != null)
                        {
                            btnHidden.CssClass = "btnHidden";
                        }
                    }
                }
            }
        }
    }
