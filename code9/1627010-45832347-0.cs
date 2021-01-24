    protected void FillGrid(string Paravalue)
    {
        try
        {
            bo.Para1 = Request.QueryString["ApplicationStatus"].ToString();//ApplicationStatus
            bo.Para2 = Session["Userid"].ToString();// SubmittedBy
            bo.Para3 = Paravalue;//Paravalue
            //DataTable dt = bl.Get_Applications(bo);
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["your connection name"].ConnectionString);
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("your query or procedure name", con);
            cmd.Parameters.AddWithValue("Para1", bo.Para1);
            cmd.Parameters.AddWithValue("Para1", bo.Para1);
            cmd.Parameters.AddWithValue("Para1", bo.Para1);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            if (dt.Rows.Count > 0)
            {
                lbl_texxt.Text = dt.Rows[0]["PositionTitle"].ToString();
            }
            else
            {
                lbl_texxt.Text = "No Data";
            }
            if (GridView1.Rows.Count > 0)
            {
                btnExport.Visible = true;
            }
            else
            {
                btnExport.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("er" + ex);
        }
    }
