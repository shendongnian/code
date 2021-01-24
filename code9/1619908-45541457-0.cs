        private void button_add_Click(object sender, EventArgs e)
        {
                    foreach (DataGridViewRow row in DataGridView1.Rows)
                    {
                        if (// condition for true)
                        {
                            row.Rows[row that should be editable].ReadOnly = true;
                        }
                        else if(// condition for false)
                        {
                            row.Rows[row that schould not be editable].ReadOnly = false;
                        }
                    }   
        }
