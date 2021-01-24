            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                adminpanel ap = new adminpanel();
                ap.Show();
            }
            else
            {
                MessageBox.Show("Check Username or Password");
            }
            }
            catch (Exception z)
            {
                MessageBox.Show("Connection error");
            }
