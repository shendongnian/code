        private void dgvEmployee_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(_newRow)
            {
                //cancel
            }
            else
            {
                //update
            }
        }
        private void dgvEmployee_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            _newRow = true;
        }
        private void dgvEmployee_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (_newRow)
            {
                //insert
                _newRow = false;
            }
           
        }
