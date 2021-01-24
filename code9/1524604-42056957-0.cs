    private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Test for Specific Key
            if(e.KeyChar == (char)Keys.Enter)
            {
                //Do Stuff like:
                button1.Enabled = true
            }
        }
