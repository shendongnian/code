    <asp:ScriptManager ID="ScriptManager1" runat="server"
    EnablePageMethods = "true">
    </asp:ScriptManager>
 
    <asp:TextBox ID="txtContactsSearch" runat="server"></asp:TextBox>
    <cc1:AutoCompleteExtender ServiceMethod="SearchCustomers"
        MinimumPrefixLength="2"
        CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
        TargetControlID="txtContactsSearch"
        ID="AutoCompleteExtender1" runat="server" FirstRowSelected = "false">
    </cc1:AutoCompleteExtender>
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchCustomers(string prefixText, int count)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["constr"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select ContactName from Customers where " +
                "ContactName like @SearchText + '%'";
                cmd.Parameters.AddWithValue("@SearchText", prefixText);
                cmd.Connection = conn;
                conn.Open();
                List<string> customers = new List<string>();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(sdr["ContactName"].ToString());
                    }
                }
                conn.Close();
                return customers;
            }
        }
    }
