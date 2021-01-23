    private void Form1_Load(object sender, EventArgs e)
            {
                dataGridView3.ContextMenu = contextMenuStrip1;
                contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            }
    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
            {
                string signatureDate = dataGridView3.CurrentRow.Cells[8].Value.ToString();
                // MessageBox.Show(signatureDate);
                if (signatureDate.Length > 5)
                {
                    contextMenuStrip1.Items[0].Visible = false;
                    contextMenuStrip1.Items[1].Visible = true;
                }
                else
                {
                    contextMenuStrip1.Items[0].Visible = true;
                    contextMenuStrip1.Items[1].Visible = false;
                }
            }
