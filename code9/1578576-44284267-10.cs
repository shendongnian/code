    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Windows.Forms;
    
    namespace Samples
    {
    	static class Program
    	{
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			var form = new Form();
    			var dgv = new DataGridView { Dock = DockStyle.Fill, Parent = form };
    			form.Load += (sender, e) =>
    			{
    				var dt = GetData();
    				dgv.DataSource = dt;
    				dgv.Columns["Mail Preference Description"].Width = 250;
    				dgv.Columns["Post"].Width = 50;
    				dgv.Columns["SMS"].Width = 50;
    				dgv.Columns["Email"].Width = 50;
    				dgv.Columns["Telephone"].Width = 75;
    				dgv.Columns["SEQ_ID"].Visible = false;
    				dgv.Columns["MAIL_PREFERENCE_ID"].Visible = false;
    				foreach (DataGridViewRow row in dgv.Rows)
    				{
    					foreach (DataGridViewCell cell in row.Cells)
    					{
    						if (cell.Value is bool && (bool)cell.Value == false)
    							cell.ReadOnly = true;
    					}
    				}
    			};
    			Application.Run(form);
    		}
    
    		static DataTable GetData()
    		{
    			var dt = new DataTable();
    			dt.Columns.Add("SEQ_ID", typeof(int));                              // SEQ_ID
    			dt.Columns.Add("MAIL_PREFERENCE_ID", typeof(string));               // MAIL_PREFERENCE_ID
    			dt.Columns.Add("Mail Preference Description", typeof(string));      // MAIL_PREFERENCE_DESC
    			dt.Columns.Add("Post", typeof(bool));                               // POST
    			dt.Columns.Add("SMS", typeof(bool));                                // SMS
    			dt.Columns.Add("Email", typeof(bool));                              // EMAIL
    			dt.Columns.Add("Telephone", typeof(bool));                          // TELEPHONE
    
    			dt.Rows.Add(1, "1", "Membership", true, true, true, true);
    			dt.Rows.Add(2, "2", "Monthly Newsletter", false, false, true, false);
    			dt.Rows.Add(3, "3", "Mothhly Technical Briefing", false, false, true, false);
    			dt.Rows.Add(4, "4", "Magazine", false, false, true, false);
    			dt.Rows.Add(5, "5", "Branch Mailings", false, true, true, false);
    			dt.Rows.Add(6, "6", "Events", true, true, true, true);
    			dt.Rows.Add(7, "7", "Qualifications", true, true, true, true);
    			dt.Rows.Add(8, "8", "Training", true, true, true, true);
    			dt.Rows.Add(9, "9", "Recruitment", true, true, true, true);
    			dt.Rows.Add(10, "A", "General", true, true, true, true);
    
    			return dt;
    		}
    	}
    }
