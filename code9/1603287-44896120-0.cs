    	    string varname = "CalculationTimeDown";
            Dictionary<string, DateTime> values = new Dictionary<string, DateTime>();
            for (int i = 0; i <= 4; i++)
            {
                // Assemble the variable name 
                values.Add(varname + i.ToString("000"), DateTime.Now.AddMinutes((i) * 30));
            }
