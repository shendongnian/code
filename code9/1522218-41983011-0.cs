    public  class MyForm
    {
        private frmPrincipal frm = null;
    
        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                this.Hide();
    
                // Re-use existing form, or activate it if it's already open
                if (frm == null || frm.IsDisposed)
                {
                    frm = new frmPrincipal();
                    frm.Show();
                }
                else
                {
                    frm.Activate();
                }
    
                frm.txtCarga.Text = dr.Cells[0].Value.ToString();
    
                frm.txtCarga.Focus();
                frm.txtCarga.SelectAll();
    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro\nDetalhes: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
