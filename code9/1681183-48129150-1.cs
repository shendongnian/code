	private void FrmDashboard_Load(object sender, EventArgs e)
	{
		DataTable dt = DAl.GetTables();
		DataTable dt1;
	   	
		if (dt.Rows.Count > 0)
		{
		   
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				o = new Available();
				if (dt.Rows[i]["Status"].ToString() == "A         ")
				{`enter code here`
					o.lblTable.BackColor = Color.DarkSeaGreen;
				}
				if (dt.Rows[i]["Status"].ToString() == "B         ")
				{
					o.lblTable.BackColor = Color.DarkRed;
				}
				else if (dt.Rows[i]["Status"].ToString() == "C         ")
				{
					o.lblTable.BackColor = Color.Blue;
				}
				o.ButtonClick1 +=new Available.EventHandler(o_ButtonClick1);	   
			    // MessageBox.Show(o.vButton1.Tag.ToString());
				o.lblTable.Text = i + "";
				 panel.Controls.Add(o);
			}
		}	
	}
	protected void o_ButtonClick1(object sender, EventArgs e)
	{
	   MessageBox.Show(o.lblTable.Text);
	}
