     protected void ddlOverallStatus_Load(object sender, EventArgs e)
        {
            ddlOverallStatus = setColor(ddlOverallStatus, false);
        }
        protected void ddlOverallStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlOverallStatus = setColor(ddlOverallStatus, true);
        }
        protected DropDownList setColor(DropDownList ddl, bool load)
        {
            if (load)
            {
                string s1 = ddl.SelectedItem.Text.ToString();
                if (s1 == "Green")
                    ddl.BackColor = System.Drawing.Color.FromArgb(0,255,0);
                else
                    ddl.BackColor = System.Drawing.Color.FromName(s1);
            }
            else
            {
                string s1 = ddl.SelectedItem.Text.ToString();
                if (s1 == "Green")
                {
                    ddl.BackColor = System.Drawing.Color.FromArgb(0, 255, 0);
                    ddl.ForeColor = System.Drawing.Color.FromArgb(0, 255, 0);
                }
                else
                {
                    ddl.BackColor = System.Drawing.Color.FromName(s1);
                    ddl.ForeColor = System.Drawing.Color.FromName(s1);
                }
            }
            return ddl;
        }
