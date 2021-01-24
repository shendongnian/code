    private void cmdConnect_Click(object sender, EventArgs e)
    {
            if (txtCommPort.Text == "")
            {
                MessageBox.Show("Invalid Port Number!");
            }
            else
            {
                comm = new GsmCommMain(txtCommPort.Text, 9600, 150);
                Cursor.Current = Cursors.Default;
                Cursor.Current = Cursors.WaitCursor;
                comm.Open();
                Cursor.Current = Cursors.Default;
                if (!comm.IsConnected())
                {
                    MessageBox.Show("No phone connected.");
                }
                else
                {
                    MessageBox.Show("Connected!");
                }
            }
    }
