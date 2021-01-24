        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            var currentRowVals = dataGridView1.Rows[e.RowIndex];
            var Id = currentRowVals.Cells[0].EditedFormattedValue;
            var FName = currentRowVals.Cells[1].EditedFormattedValue;
            var LName = currentRowVals.Cells[2].EditedFormattedValue;
            var EmpType = currentRowVals.Cells[3].EditedFormattedValue;
            var Salary = currentRowVals.Cells[4].EditedFormattedValue;
            if (dataGridView1.IsCurrentCellDirty)
            {
                if (Id.ToString() == "-1")
                {
                    //do add
                }
                else
                {
                    //do edit
                }
            }
        }
