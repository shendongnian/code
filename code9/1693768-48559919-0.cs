    var regNo = Request.QueryString["RegNo"];
	if(!string.IsNullOrEmpty(regNo) && IsDigitsOnly(regNo.ToString().Trim()))
	{
     num = Convert.ToInt32(regNo.ToString());
	}
    private bool IsDigitsOnly(string str)
	{
	    foreach (char c in str)
	    {
	        if (!char.IsDigit(c))
			{
	            return false;
	        }
	    }
	
	    return true;
	}
