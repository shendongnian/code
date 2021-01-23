      protected void addBtn_Click(object sender, EventArgs e)
        {
            if (Session["Count"]==null)
	        {
                Session["Count"] = 0;
	        }
            count = int.Parse(Session["Count"]);
            int qty = Convert.ToInt32(qtyDDL.SelectedValue);  // <--number of rooms admin wants to add
            count++;
            roomtypeDDL.Enabled = false;
            qtyDDL.Enabled = false;
            if (count < qty)
            {
                string roomid = roomidBox.Text;
                string rtype = roomtypeDDL.SelectedItem.ToString();
            }
            else
            {
                roomidBox.Enabled = false;
                roomtypeDDL.Enabled = true;
                addBtn.Enabled = false;
                addBtn.BackColor = System.Drawing.ColorTranslator.FromHtml("#2C2A2A");
            }
            Session["Count"] = count;
        }
