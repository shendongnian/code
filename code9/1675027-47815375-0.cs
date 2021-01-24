    <asp:HiddenField ID="ID" runat="server" Value='<%# Eval("ID") %>' />
     protected void Repeater2_ItemDataBound(object sender System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        SqlConnection con = new SqlConnection(ConString);
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater Repeater2 = (Repeater)e.Item.FindControl("EquipmentRepeater");
            System.Data.DataTable ds = new System.Data.DataTable();
            SqlCommand cmd1 = new SqlCommand(" Select HourID, Equip,Location FROM Equip where HourID=@id");
              HiddenField id = (HiddenField)e.Item.FindControl("ID");
                int parsedId = int.Parse(id.Value);
                cmd1.Parameters.Add("@id", SqlDbType.Int).Value = parsedId;
            con.Open();
            cmd1.Connection = con;
            cmd1.ExecuteReader();
            con.Close();
            SqlDataAdapter ad = new SqlDataAdapter(cmd1);
            // DataTable ds = new DataTable();
            ad.Fill(ds);
            con.Close();
            //Need to assign the Data in datatable
            Repeater2.DataSource = ds;
            Repeater2.DataBind();
        }
    }
