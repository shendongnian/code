     while (rdr.Read())
            {
                DataRow dr = dtTutorial.NewRow();
                dr["Topic"] = rdr["Topic"];
                dr["Description"] = rdr["Description"];
                dr["Visit"] = rdr["id"];
                dtTutorial.Rows.Add(dr);
            }
            con.Close();
        }
        GridView1.DataSource = dtTutorial;
        GridView1.DataBind();
        foreach (GridViewRow gr in GridView1.Rows)
        {
            HyperLink hp = new HyperLink();
            hp.Text = "Click here";
            hp.NavigateUrl = "~/Details.aspx?id=" + gr.Cells[2].Text;
            gr.Cells[2].Controls.Add(hp);
        }
