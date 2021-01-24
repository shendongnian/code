    protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (DataListItem item in DataList1.Items)
            {
                RadioButton rd_CS = (RadioButton)item.FindControl("rd_CS");
                RadioButton rd_CS2 = (RadioButton)item.FindControl("rd_CS2");
                RadioButton rd_CS3 = (RadioButton)item.FindControl("rd_CS3");
                RadioButton rd_CS4 = (RadioButton)item.FindControl("rd_CS4");
                if (rd_CS.Checked)
                {
                    Insert(rd_CS.Text); //Here you can insert whatever value you want, I tried with Text of radiobutton
                }
                if (rd_CS2.Checked)
                {
                    Insert(rd_CS2.Text); //Here you can insert whatever value you want, I tried with Text of radiobutton
                }
                if (rd_CS3.Checked)
                {
                    Insert(rd_CS3.Text); //Here you can insert whatever value you want, I tried with Text of radiobutton
                }
                if (rd_CS4.Checked)
                {
                    Insert(rd_CS4.Text); //Here you can insert whatever value you want, I tried with Text of radiobutton
                }
            }
        }
