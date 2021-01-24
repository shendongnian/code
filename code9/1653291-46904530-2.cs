    public partial class _Default : Page
      {
            SqlConnection con;
            SqlDataAdapter dad;
            DataSet ds;
            string SqlQuery = "";
            string cliente;
            protected void Page_Load(object sender, EventArgs e)
            {
                if (Session["cliente"] != null)
                {
                    cliente = Session["cliente"].ToString();
                }
                else
                    cliente="";
                con = new SqlConnection(Globals.strConnection);
                SqlQuery = "SELECT * FROM Tab1 WHERE c15 = '" + cliente + "'";
                dad = new SqlDataAdapter(SqlQuery, con);
                ds = new DataSet();
                con.Open();
                dad.Fill(ds);
                con.Close();
                for (int c = 0; c < ds.Tables[0].Rows.Count; c++)
                {
                    for (int i = 1; i < ds.Tables[0].Columns.Count - 1; i++)
                    {
                        ds.Tables[0].Rows[c][i] = EncryptD.Decrypt(ds.Tables[0].Rows[c][i].ToString());
                    }
                }
                grvApparati.DataSource = ds;
                if (!IsPostBack)
                    grvApparati.DataBind();
                for (int c = 0; c < grvApparati.Rows.Count;c++)
                {
                    grvApparati.Rows[c].Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grvApparati, "Select$" + c); 
                }
                if (Session["editindex"] != null)
                {
                    grvApparati.EditIndex = Convert.ToInt32(Session["editindex"]);
                    grvApparati.SelectedIndex = Convert.ToInt32(Session["editindex"]);
                    DataBind();
                    Session["editindex"] = null;
                    btnSalva.Visible = true;
                }
            }
    
    
            protected void btnAggiungi_Click(object sender, EventArgs e)
            {
                int id;
                DataSet tmpds = new DataSet();
                SqlQuery = "SELECT MAX(ID) FROM Tab1 ";
                SqlCommand cmd = new SqlCommand(SqlQuery, con);
                con.Open();
                dad = new SqlDataAdapter(SqlQuery, con);
                dad.Fill(tmpds);
                if (tmpds.Tables[0].Rows[0][0].ToString() == "")
                    id = 1;
                else
                    id = Convert.ToInt32(tmpds.Tables[0].Rows[0][0]) + 1;
                SqlQuery = "INSERT INTO Tab1 (ID, c15) VALUES (" + id + ", '" + cliente + "')";
                cmd = new SqlCommand(SqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Session["editindex"] = grvApparati.Rows.Count;
                Response.Redirect("/Apparati.aspx");
            }
            protected void grvApparati_RowEditing(object sender, GridViewEditEventArgs e)
            {
                grvApparati.EditIndex = e.NewEditIndex;
    
                DataBind();
            }
    
    
            protected void btnModifica_Click(object sender, ImageClickEventArgs e)
            {
                grvApparati.EditIndex = grvApparati.SelectedIndex;
                btnSalva.Visible = true;
                DataBind();
            }
    
            protected void btnRipristina_Click(object sender, ImageClickEventArgs e)
            {
                grvApparati.EditIndex = -1;
                Response.Redirect("/Apparati.aspx");
            }
    
    
    
            protected void grvApparati_SelectedIndexChanged(object sender, EventArgs e)
            {
                foreach (GridViewRow row in grvApparati.Rows)
                {
                    if (row.RowIndex == grvApparati.SelectedIndex)
                    {
                        row.Style.Value = "background:#dbe8f9;";
                    }
                    else
                    {
                        row.Style.Value = "background:white;";
                    }
                }
            }
    
    
            protected void btnCancella_Click(object sender, ImageClickEventArgs e)
            {
                int id = Convert.ToInt32(grvApparati.DataKeys[grvApparati.SelectedIndex].Value.ToString());
                con.Open();
                SqlQuery = "DELETE FROM Tab1 WHERE ID = " + id;
                SqlCommand cmd = new SqlCommand(SqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("/Apparati.aspx");
            }
    
            protected void btnSalva_Click(object sender, ImageClickEventArgs e)
            {
                int id = Convert.ToInt32(grvApparati.DataKeys[grvApparati.EditIndex].Value.ToString());
                GridViewRow row = (GridViewRow)grvApparati.Rows[grvApparati.EditIndex];
                TextBox c1 = (TextBox)row.Cells[2].Controls[0];
                TextBox c2 = (TextBox)row.Cells[3].Controls[0];
                TextBox c3 = (TextBox)row.Cells[4].Controls[0];
                TextBox c4 = (TextBox)row.Cells[5].Controls[0];
                TextBox c5 = (TextBox)row.Cells[6].Controls[0];
                TextBox c6 = (TextBox)row.Cells[7].Controls[0];
                TextBox c7 = (TextBox)row.Cells[8].Controls[0];
                TextBox c8 = (TextBox)row.Cells[9].Controls[0];
                TextBox c9 = (TextBox)row.Cells[10].Controls[0];
                TextBox c10 = (TextBox)row.Cells[11].Controls[0];
                TextBox c11 = (TextBox)row.Cells[12].Controls[0];
                TextBox c12 = (TextBox)row.Cells[13].Controls[0];
                TextBox c13 = (TextBox)row.Cells[14].Controls[0];
                TextBox c14 = (TextBox)row.Cells[15].Controls[0];
    
                con.Open();
                SqlQuery = "UPDATE Tab1 SET c1 = '" + EncryptD.Encrypt(c1.Text) + "', " +
                    "c2 = '" + EncryptD.Encrypt(c2.Text) + "', " +
                    "c3 = '" + EncryptD.Encrypt(c3.Text) + "', " +
                    "c4 = '" + EncryptD.Encrypt(c4.Text) + "', " +
                    "c5 = '" + EncryptD.Encrypt(c5.Text) + "', " +
                    "c6 = '" + EncryptD.Encrypt(c6.Text) + "', " +
                    "c7 = '" + EncryptD.Encrypt(c7.Text) + "', " +
                    "c8 = '" + EncryptD.Encrypt(c8.Text) + "', " +
                    "c9 = '" + EncryptD.Encrypt(c9.Text) + "', " +
                    "c10 = '" + EncryptD.Encrypt(c10.Text) + "', " +
                    "c11 = '" + EncryptD.Encrypt(c11.Text) + "', " +
                    "c12 = '" + EncryptD.Encrypt(c12.Text) + "', " +
                    "c13 = '" + EncryptD.Encrypt(c13.Text) + "', " +
                    "c14 = '" + EncryptD.Encrypt(c14.Text) + "', " +
                    "c15 = '" + cliente + "' WHERE ID = " + id;
                SqlCommand cmd = new SqlCommand(SqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
                grvApparati.EditIndex = -1;
                DataBind();
                Response.Redirect("/Apparati.aspx");
                
            }
