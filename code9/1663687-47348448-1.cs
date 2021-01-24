    protected void  GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
       //get selected row
       GridRow  selectedRow = GridView1.Rows[GridView1.SelectedIndex];
     
       //check if it's a checkbox column and set Session variable, if it is
       if(selectedRow.Cells[23].Controls[0] is CheckBox) {
         bool isChecked = (selectedRow.Cells[23].Controls[0] as CheckBox).Checked;
         Session["customs_Clearance"] = (isChecked == true ? "checked" : "unchecked");
       }
    }
