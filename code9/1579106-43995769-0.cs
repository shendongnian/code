     private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var p =(ColNameText) comboBoxEx1.SelectedItem;
            var result= from q in list where q.GetType().GetProperty(p.colname).GetValue(q,null).ToString().Contains(txtSearch.Text) select q;
            dgvListDrivers.DataSource = result.ToList();
            
        }
