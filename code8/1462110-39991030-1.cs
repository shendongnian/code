	    public static class ListControlExtensions
	    {
	        public static object GetItemValue(this ListControl list, object item)
	        {
	            if (item == null)
	                throw new ArgumentNullException("item");
	
	            if (string.IsNullOrEmpty(list.ValueMember))
	                return item;
	
	            var property = TypeDescriptor.GetProperties(item)[list.ValueMember];
	            if (property == null)
	                throw new ArgumentException(
	                    string.Format("item doesn't contain '{0}' property or column.",
	                    list.ValueMember));
	            return property.GetValue(item);
	        }
	    }
	//.........................................
		void cmdGetPCs()
		{
      		const string q = "SELECT SISSI & ' (' & IP & ') - ' & DESCRIPTION as LONGDESCR, MAC from PC_LIST WHERE active = true order by sissi, ip"; //use & instead of + to have blankspace instead of null values for displaying PCs without Sissi because CONCAT doesn't work (MS Access....)
			
      		OleDbDataAdapter da = new OleDbDataAdapter();
			DataSet ds = new DataSet();
      		
      		vcon.Open();
				da.SelectCommand = new OleDbCommand(q, vcon);
      		vcon.Close();
      		
			da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
			da.Fill(ds, "tblPCs");
			DataTable dtPC = ds.Tables["tblPCs"];
			
			foreach (DataRow dtRow in dtPC.Rows)
	        {
				lstPCs.Items.Add(new KeyValuePair<String, String>(dtRow["LONGDESCR"].ToString(), dtRow["MAC"].ToString()));
	        }
			lstPCs.DisplayMember = "Key";
			lstPCs.ValueMember = "Value";
		}
	//.........................................
		private void Dataset_get(string mymac)
		{
      		string qp = "";
      		switch (mypermissions)
      		{
      			case "ADMIN":
      				qp = "SELECT USER_TYPE, HAS_ADMIN, USER_NAME, PASSWORD FROM PASSWORDS WHERE ID = '" + mymac + "' ORDER BY user_type";break;
      			case "USER":
      				qp = "SELECT p.USER_TYPE, p.HAS_ADMIN, p.USER_NAME, p.PASSWORD FROM PASSWORDS p, PC_LIST pc WHERE p.ID = '" + mymac + "' and p.ID = pc.MAC and (pc.x_plant like '%USER%' or (ucase(p.user_type) not like '%ADMIN%')) ORDER BY p.user_type";break;
      			default: break;
      		}
      		
      		OleDbDataAdapter dapass = new OleDbDataAdapter();
      		DataSet dspass = new DataSet();
			vcon.Open();
				dapass.SelectCommand =  new OleDbCommand(qp, vcon);
      		vcon.Close();
			dapass.MissingSchemaAction = MissingSchemaAction.AddWithKey;
			dapass.Fill(dspass,"tblPass");
			DataTable dtPass = new DataTable();
			dtPass = dspass.Tables["tblPass"];
			dataGridView1.DataSource = dtPass;
		}
	//.........................................
		void ListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			groupBox1.Text = lstPCs.GetItemText(lstPCs.SelectedItem);
			string x = lstPCs.GetItemValue(lstPCs.SelectedItem).ToString();
			Dataset_get(x);
		}
