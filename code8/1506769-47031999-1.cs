        add  <cc1:ToolkitScriptManager></cc1:ToolkitScriptManager> instead of   <asp:ScriptManager></asp:ScriptManager>
    
    your aspx page  ----
        
        <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server" 
        EnablePageMethods = "true">
        </cc1:ToolkitScriptManager>
        
        <asp:TextBox ID="txtContactsSearch" runat="server"></asp:TextBox>
                   <cc1:AutoCompleteExtender ServiceMethod="SearchCustomers" MinimumPrefixLength="1" CompletionInterval="10"  
                    EnableCaching="false" CompletionSetCount="10" TargetControlID="txtContactsSearch" ID="AutoCompleteExtender2"  
                    runat="server" FirstRowSelected="false"></cc1:AutoCompleteExtender>  
            
            
        your cs page----
        
        [System.Web.Script.Services.ScriptMethod()]
                [System.Web.Services.WebMethod]
                public static List<string> SearchCustomers(string prefixText, int count)
                {
        
                    using (SqlConnection conn = new SqlConnection())
                    {
                        conn.ConnectionString = ConfigurationManager
                                .ConnectionStrings["conio"].ConnectionString;
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "select clientID from clientsDetails where "+"clientID like @SearchText + '%'";
                            cmd.Parameters.AddWithValue("@SearchText", prefixText);
                            cmd.Connection = conn;
                            conn.Open();
                            List<string> customers = new List<string>();
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    customers.Add(sdr["name"].ToString());
                                }
                            }
                            conn.Close();
                            return customers;
                        }
                    }
                }
