    var errors = new List<string>();
	try
	{ 
	    //your code here 
	}
	catch(Exception ex) {
	    errors.Add(ex.InnerException.ToString());
    }
	var sb = new StringBuilder();
	foreach (var errorMessage in errors)
	{	
		sb.AppendLine(errorMessage);
	}
	if (errors.Count > 0)
	{
		MessageBox.Show(sb.ToString(), "Errors Present", MessageBoxButton.OK, MessageBoxImage.Error);
	}
