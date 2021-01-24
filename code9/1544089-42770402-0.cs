     protected void ddl_request_action_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = ddl_request_action.SelectedIndex;
              
                if (selected == 3 || selected == 4)
                {
                    pnl_charge_code.Visible = true;
                    rfv_charge_code.Enabled = true;
                }
                else
                {
                    pnl_charge_code.Visible = false;
                    rfv_charge_code.Enabled = false;
                }
            
        }
