        private void dgvConnections_DoubleClick(object sender, EventArgs e)
        {
                    //Ensure the double click isn't firing when the mouse is clicked anywhere over the column headers/ column separators. 
                    DataGridView.HitTestInfo hit = dgvConnections.HitTest(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
                    if (hit.RowIndex == -1)
                        return;
            //my code here, which should run on double click
        }
