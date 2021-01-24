    private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        try
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            this.Hide();
            frmPrincipal frm = new frmPrincipal();
    
            frm.txtCarga.Text = dr.Cells[0].Value.ToString();
            frm.Show(); // <-- Add this
        
            frm.txtCarga.Focus();
            frm.txtCarga.SelectAll();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro\nDetalhes: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
