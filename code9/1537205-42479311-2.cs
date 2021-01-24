    private void btnSave_Click(object sender, EventArgs e) {
    TabControl.TabPageCollection pages = tbAddItem.TabPages;
    foreach (TabPage page in pages) {
            DataGridView dgv = (DataGridView)page.Controls[0];
            dgv...
        }
    }
