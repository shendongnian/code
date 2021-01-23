        protected void myCheckBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool enableGrid = true;
            foreach (ListItem listItem in ddlStatus.Items)
            {
                if (listItem.Value == "30" && listItem.Selected == true)
                {
                    enableGrid = false;
                }
            }
            
            if (enableGrid == true)
            {
                //enable grid and/or row inserts here
                Label1.Text = "enabled";
            }
            else
            {
                //disable grid and/or row inserts here
                Label1.Text = "disabled";
            }
        }
