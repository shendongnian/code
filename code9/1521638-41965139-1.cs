    public string dataValue = "";
    private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        try
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            dataValue = dr.Cells[0].Value.ToString();
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro\nDetalhes: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
