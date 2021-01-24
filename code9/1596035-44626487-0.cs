        private void lv_edit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_edit.SelectedIndices.Count > 0)
            {
                var lvi = lv_edit.SelectedItems[0];
                tb_col1.Text = lvi.SubItems[0].Text;
                date_col2.Value = Convert.ToDateTime(lvi.SubItems[1].Text);
                combo_col3.SelectedIndex = combo_col3.FindStringExact(lvi.SubItems[2].Text);
            }
        }
        private void cb_updateItem_Click(object sender, EventArgs e)
        {
            if (lv_edit.SelectedIndices.Count > 0)
            {
                var lvi = lv_edit.SelectedItems[0];
                lvi.SubItems[0].Text = tb_col1.Text;
                lvi.SubItems[1].Text = date_col2.Value.ToString("dddd, dd. MMMM yyyy");
                lvi.SubItems[2].Text = combo_col3.SelectedItem.ToString();
            }
        }
