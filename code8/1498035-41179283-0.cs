       protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
          string pName = GridView2.SelectedRow.Cells[1].Text;
          string Jmeno = GridView2.SelectedRow.Cells[2].Text;
          Label1.Text = "<b>pName :</b> " + ID + " <b>Jmeno :</b> " + Jmeno;
        }
