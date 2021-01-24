     private void btnAdd_Click(object sender, EventArgs e)
    {
        string firstColum = txtUomtyp.Text;
        string secondColum = txtUomDesc.Text;
        string[] row = { firstColum, secondColum };
        dgvUom.Rows.Add(row);
    }
 
