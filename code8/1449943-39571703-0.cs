    using System;
    using System.Web;
    using System.Data;
    using System.Data.SqlClient;
        namespace GridviewTOExcel
        {
          public partial class WebForm1 : System.Web.UI.Page
          {
            private SqlConnection con;
            private SqlCommand cmd;
            private string constr, query;
    
            private void connection()
            {
                string dbConnectiomName = "conStr"; // Set your keyname from web.config file
                constr = WebConfigurationManager.ConnectionStrings[dbConnectiomName].ToString();
                con = new SqlConnection(constr);
                con.Open();
            }
        
        	 protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    gvBind(); // Bind Gridview on pageload
                }
            }
            
            // Function which bind gridview control  
        	Public void gvBind(){
        	
        	   connection();
                cmd = new SqlCommand();
                cmd.CommandText = "Select Query"; // best practise is to use storedprocedure
                cmd.CommandType = CommandType.Text;
        	    cmd.Connection = con;
                cmd.CommandTimeout = 0;
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                dap.Fill(ds);
        
        		GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
        
        	}
         }
        }
