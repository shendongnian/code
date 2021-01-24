    if (!string.IsNullOrEmpty(destin) && string.IsNullOrEmpty(depar))
    {
    	try
    	{
    		writer.WriteLine("SearchDest");
    		writer.WriteLine(destin);
    		string retur = reader.ReadLine();
    		Debug.WriteLine(retur);
    		string[] tokens = retur.Split('-');
    		flight.Clear();
    		
    		foreach (string s in tokens)
    		{
    			Debug.WriteLine(s);
    			if (!string.IsNullOrEmpty(s))
    			{
    				string[] flyelem = s.Split(',');
    				int idf;
    				int frees;
    
    				if (int.TryParse(flyelem[0], out idf) &&
    					int.TryParse(flyelem[3], out frees))
    				{
    
    					string destf = flyelem[1];
    					string airf = flyelem[2];
    					string datef = flyelem[4];
    					Flight b = new Flight(idf, destf, airf, frees, datef);
    					flight.Add(b);
    				}
    			}
    		}
    
    		dataGridView3.DataSource = null;
    		dataGridView3.Refresh();
    		dataGridView3.DataSource = flight;
    	}
    	catch (Exception ex)
    	{
    		MessageBox.Show(ex.ToString());
    	}
    }
