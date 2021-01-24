    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Double From = Convert.ToDouble("0"+dataGridView1.CurrentRow.Cells["RangeFrom"].Value);
            Double To = Convert.ToDouble("0" + dataGridView1.CurrentRow.Cells["RangeTo"].Value);
            Double Result = Convert.ToDouble("0" + dataGridView1.CurrentRow.Cells["Result"].Value);
            if (Result >= From && Result <= To)
            {
                dataGridView1.CurrentRow.Cells["Status"].Value = "Normal";
            }
            else
            {
                dataGridView1.CurrentRow.Cells["Status"].Value = "Abnormal";
            }
        }
