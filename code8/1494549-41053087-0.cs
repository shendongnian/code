    protected void qtyDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (qtyDDL.SelectedIndex == 0)
                {
                    //My Code
                }
                else
                {
                    Session["Count"] = 0; // <-- sets count to 0 every click on quantity
                }
            }
            catch(Exception ex)
            {
                Label1.Text = ex.Message;
            }
            
        }
     protected void addBtn_Click(object sender, EventArgs e)
        {
            count = Convert.ToInt32(Session["Count"]); // <-- set variable 
            roomtypeDDL.Enabled = false;
            qtyDDL.Enabled = false;
            string rtype, roomid;
            if(count < Convert.ToInt32(Session["qty"]))
            {
                string roomid = roomidBox.Text;
                string rtype = roomtypeDDL.SelectedItem.ToString();
            }
            count++;
            if (count == Convert.ToInt32(Session["qty"])) // <--Disable Add Button
            {
                roomidBox.Enabled = false;
                roomtypeDDL.Enabled = true;
                roomtypeDDL.SelectedIndex = 0;
                qtyDDL.SelectedIndex = 0;
                addBtn.Enabled = false;
                addBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#2C2A2A");
            }
            Session["Count"] = count;
        }
