    public void Schip()
    {    
        using (SqlConnection thisConnection = new SqlConnection("Data Source=VMB-LP12;Initial Catalog=SmmsData;Integrated Security=True"))
        {
            string oString = "Select SchipNaam, RederijNr, Lengte, Laadvermogen FROM AlgSchipInfo";
            SqlCommand oCmd = new SqlCommand(oString, thisConnection);
    
            thisConnection.Open();
            using (SqlDataReader oReader = oCmd.ExecuteReader())
            {
                int i = 0;
                while (oReader.Read())
                // for (int i = 0; i < count; i++)
                {
    
                    System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
                    new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    createDiv.ID = "createDiv";
                    this.Controls.Add(createDiv);
                    List<TextBox> tb_names = new List<TextBox>();
                    TextBox tb_name = new TextBox();
    
                    //TextBox tb_name = new TextBox();
                    tb_name.ID = "CreateT_" + i.ToString() + "_1";
                    tb_name.Text = (oReader["SchipNaam"].ToString());
                    createDiv.Controls.Add(new LiteralControl
                    ("<div class='form-group'><div class='clearfix' ></div><div class='row'><div class='col-md-3'></div><div class='col-md-3'> Scheepspnaam: <input type='text' value='" + tb_name.Text + "' id='" + tb_name.ID + "' runat='server'/></div></div></div>"));
                    tb_names.Add(tb_name);
    
                    //TextBox tb_name1 = new TextBox();
                    tb_name.ID = "CreateT_" + i.ToString() + "_2";
                    tb_name.Text = (oReader["RederijNr"].ToString());
                    createDiv.Controls.Add(new LiteralControl
                    ("<div class='form-group'><div class='clearfix' ></div><div class='row'><div class='col-md-3'></div><div class='col-md-3'> RederijNr:<input type='text' value='" + tb_name.Text + "' id='" + tb_name.ID + "' runat='server'/></div></div></div>"));
                    tb_names.Add(tb_name);
    
                    //TextBox tb_name2 = new TextBox();
                    tb_name.ID = "CreateT_" + i.ToString() + "_3";
                    tb_name.Text = (oReader["Lengte"].ToString());
                    createDiv.Controls.Add(new LiteralControl
                    ("<div class='form-group'><div class='clearfix' ></div><div class='row'><div class='col-md-3'></div><div class='col-md-3'> Lengte  :<input type='text' value='" + tb_name.Text + "' id='" + tb_name.ID + "' runat='server'/></div></div></div>"));
                    tb_names.Add(tb_name);
    
                    //TextBox tb_name3 = new TextBox();
                    tb_name.ID = "CreateT_" + i.ToString() + "_4";
                    tb_name.Text = (oReader["Laadvermogen"].ToString());
                    createDiv.Controls.Add(new LiteralControl
                    ("<div class='form-group'><div class='clearfix' ></div><div class='row'><div class='col-md-3'></div><div class='col-md-3'> Laadvermogen:<input type='text' value='" + tb_name.Text + "' id='" + tb_name.ID + "' runat='server'/></div></div></div>"));
                    tb_names.Add(tb_name);
                    i++;
                }
            }
        }
    }
