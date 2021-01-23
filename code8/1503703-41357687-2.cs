	var StartDate = comboBoxDate1.Text;
	var EndDate = comboBoxDate2.Text;
	var eDate = Convert.ToDateTime(EndDate);
	var sDate = Convert.ToDateTime(StartDate);
	if(StartDate != "" && StartDate != "" && sDate > eDate)
	{
		Console.WriteLine("Please ensure that the End Date is greater than the Start Date.");
	}
