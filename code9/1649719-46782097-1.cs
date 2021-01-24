     protected void gvdata_SelectedIndexChanged(object sender, EventArgs e)
    {
        lable.Text = "";
        lable.ForeColor = Color.White ;
      lable.Text = gvData.SelectedRow.Cells[0].Text;
        dlItemID.ClearSelection();
       dlItemID.Items.FindByValue(Lable.Text).Selected = true;
        
    }
