    if (EmployeeTb.Text != string.Empty)
    {
        ResultsFLP.Controls.Clear(); 
    	var emp = Cerealto.Classes.Employees.EmployeeList.AsEnumerable().Where(x=> (x.firstName+ " " + x.lastName).ToLower().Contains(EmployeeTb.Text.ToString().ToLower().Trim())).Select(e=>e).ToList();
    	
    	if(emp != null)
    	{
    		foreach(Cerealto.Classes.Employee Employee e in emp)
    		{
    			 ESR = new EmployeeSearchResultUC(e.employeeID, e.firstName + " " + e.lastName);
                 ResultsFLP.Controls.Add(ESR);
    		}
    	}
    }
    else
    {
    	// there is no results here clear everything or make no change (dont use the line ResultsFLP.Controls.Clear(); / load all employees again)
        ResultsFLP.Controls.Clear();
    }
