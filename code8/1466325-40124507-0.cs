    if(e.Button == MouseButtons.Right)
            {
                string signatureDate = dataGridView3.CurrentRow.Cells[8].Value.ToString();
                // MessageBox.Show(signatureDate);
                if(signatureDate.Length > 5)
                {
                    dataGridView3.ContextMenu.Items[0].Visible = false;
                    dataGridView3.ContextMenu.Items[1].Visible = true;
                }else
                {
                    dataGridView3.ContextMenu.Items[0].Visible = true;
                    dataGridView3.ContextMenu.Items[1].Visible = false;
                }
            }
