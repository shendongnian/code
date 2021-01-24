     string sTitle = "";
                if (CheckBox1.Checked)
                {
                    sTitle += CheckBox1.Text + " ";
                }
                if (CheckBox2.Checked)
                {
                    sTitle += CheckBox2.Text + " ";
                }
                this.Title = sTitle;
