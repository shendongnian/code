    private void btnLOGIN_Click(object sender, EventArgs e)
        { 
	        try
            {
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);//set time to load
               
                if (txtUser.Text == "admin" && txtPass.Text == "")
                {
                    this.Hide();
                    MENU ss = new MENU();
                    MessageBox.Show("Welcome to CornerFlag's Product Monitoring System!", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ss.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Input , Try Again ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUser.Clear();
                    txtPass.Clear();
                };
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            
        }
