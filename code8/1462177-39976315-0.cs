    StringBuilder sbPE = new StringBuilder();
    StringBuilder sbProduction = new StringBuilder();
    StringBuilder sbPotential = new StringBuilder();
    	
    for (int i=0; i<366; i++)
    {
    	if (i > 0)
    	{
    		sbPE.Append(string.Concat(",",textBox2.Text));
		    sbProduction.Append(string.Concat(",",forecast[i,2]));
		    sbPotential.Append(string.Concat(",",forecast[i,3]));
    	}
    	else
    	{
    		sbPE.Append(textBox2.Text);
    		sbProduction.Append(forecast[i,2]);
    		sbPotential.Append(forecast[i,3]);
    	}
    }
    cmdLossDB.Parameters.AddWithValue("@PE", sbPE.ToString());
    cmdLossDB.Parameters.AddWithValue("@Production_Time", sbProduction.ToString());
    cmdLossDB.Parameters.AddWithValue("@Potential", sbPotential.ToString());
  
