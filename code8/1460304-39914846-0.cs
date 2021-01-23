	try
	{
		int companyA = 0,companyB=0;
		using(var con = new SqlConnection("connectionStringHere"))
		{
			con.Open();
			using(SqlCommand cmdc = new SqlCommand("SELECT SUM(Credited_amount) FROM IMS_Credit_Dir WHERE Credit_comp_id=1 AND Crdt_typ_id=1", con))
			{
				using(SqlDataReader drc = cmdc.ExecuteReader())
				{
					if (drc.Read())
					{
						companyA = drc.IsDBNull(0) ? 0 : drc.GetInt(0);
					}
				}
			}
			using(SqlCommand cmdcp = new SqlCommand("SELECT SUM(Credited_amount) FROM IMS_Credit_Dir WHERE Credit_comp_id=2 AND Crdt_typ_id=1", con))
			{
				using(SqlDataReader drcp = cmdcp.ExecuteReader())
				{
					if (drcp.Read())
					{
						companyB = drcp.IsDBNull(0) ? 0 : drcp.GetInt(0);
					}
				}
			}
			
			// if you are not going to do anything with these values if its not a post back move the check to the top of the method
			// and then do not execute anything if it is a postback
			// ie:  // if (Page.IsPostBack) return;
			if (!Page.IsPostBack) 
			{
				int total = (companyA+companyB);
				count_total_lbl.Text = "Rs." + " " + total.ToString();
				count_comapnya_lbl.Text = "Rs." + " " + companyA.ToString();
				count_companyb_lbl.Text ="Rs."+" "+ companyB.ToString();
			}
		}
	}
	catch(Exception ex) { Label2.Text = ex.ToString(); }
