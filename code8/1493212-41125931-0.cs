           private void LoadData()
        {
            int id = Convert.ToInt32(Request.QueryString["uid"]);
            SqlDataAdapter da = new SqlDataAdapter("", connection);
            DataTable dt = new DataTable();
            da.SelectCommand.CommandText = "Select * from Drink where DrinkID=@id";
            da.SelectCommand.Parameters.AddWithValue("@id", id);
            da.Fill(dt);
            TxtName.Text = dt.Rows[0]["DrinkName"].ToString();
            TxtDesc.Text = dt.Rows[0]["Description"].ToString();
            picname = dt.Rows[0]["DrinkPicture"].ToString();
            string kind = dt.Rows[0]["DrinkType"].ToString();
            if (kind == Rbwarm.Text)
            {
                Rbwarm.Checked=true;
            }
            else
                Rbcool.Checked=true;
            if (Rbwarm.Checked)
            {
                kind = Rbwarm.Text;
            }
            else
            {
                kind = Rbcool.Text;
            }
        }
