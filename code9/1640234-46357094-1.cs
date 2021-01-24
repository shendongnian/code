    protected void btnADD_Click(object sender, EventArgs e)
            {
                ClearADDform();
                mpeADD.Show(); //show the MPE control when the user has clicked the ADD button control
            }
    
            protected void btnOK_Click(object sender, EventArgs e)
            {
                Page.Validate("vgAdd");
                if (Page.IsValid)
                {
                    try
                    {
    //blahblah
    
                        //hide the mpe
                        mpeADD.Hide();
    
                        //reload the page
                        Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    }
                    catch (Exception exc)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert('" + exc.Message + "');", true);
                    }
                }
                else
                    //show the mpe and continue showing until either CANCEL or fields are validated
                    mpeADD.Show();
            }
    
            protected void btnCAN_Click(object sender, EventArgs e)
            {
                mpeADD.Hide();
            }
    
            protected void ClearADDform()
            {
                txtLOGIN.Text = string.Empty;
                cbISActive.Checked = true;
                txtPWD.Text = string.Empty;
                ddlAgent.SelectedIndex = -1;
            }
