    @using System.Configuration
    
    @using System.Data.SqlClient
    
    @functions{
       private SqlDataReader myReader;
 
       // Official place to provide data preparation. Is automatically called by 2SexyContent
       public override void CustomizeData()
       {
             var conString = ConfigurationManager.ConnectionStrings[Content.ConnectionName].ToString();
             var con = new SqlConnection(conString);
             con.Open();
             var command = new SqlCommand("Select Top 10 * from Files Where PortalId = @PortalId", con);
             command.Parameters.Add("@PortalId", Dnn.Portal.PortalId);
             myReader = command.ExecuteReader();
       }
    }
    <div class="sc-element">
       @Content.Toolbar
       <h1>Simple Demo using DataReader access</h1>
       <p>This demo accesses the data directly, uses a SQL parameter for the PortalId then shows the first 10 files it finds. More intro-material for direct database access in this <a href="http://www.codeproject.com/Articles/4416/Beginners-guide-to-accessing-SQL-Server-through-C" target="_blank">article on codeplex</a>.</p>
       <h2>The top 10 files found in this portal</h2>
       <ol>
             @while (myReader.Read())
             {
                    <li>@myReader["FileName"]</li>
             }
       </ol>
       @{
             myReader.Close();
       }
    </div>
