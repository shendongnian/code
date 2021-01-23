    bool isConfirmed = (bool)cmd.Parameters["@bit"].Value;
    if(isConfirmed ){
                    desc.Text = cmd.Parameters["@desc"].Value.ToString();
                    stt.Text = cmd.Parameters["@st"].Value.ToString();
                    camp = cmd.Parameters["@camp"].Value.ToString();
                    if (stt.Text.Equals("APPLIED"))
                    {
                        stt.ForeColor = System.Drawing.Color.LawnGreen;
                    }
                    else
                    {
                        stt.ForeColor = System.Drawing.Color.Firebrick;
                        label3.Enabled = true;
                        newstatus.Enabled = true;
                        update.Enabled = true;
                    }
    
    }
    else{
    MessageBox.Show("Doesn't exits!");
    }
