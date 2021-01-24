     private void btnAdd_Click(object sender, EventArgs e)
    {
        string firstColum = textbox1.Text;
        string secondColum = textbox2.Text;
        string[] row = { firstColum, secondColum };
        datagridview1.Rows.Add(row);
    }
 
