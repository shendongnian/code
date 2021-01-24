    void Main()
    {
	DateTime date = DateTime.Today;
	var exchangeService = new ExchangeService();
	SearchFilter greaterThanfilter = new SearchFilter.IsGreaterThanOrEqualTo(ItemSchema.DateTimeReceived, date);
	SearchFilter lessThanfilter = new SearchFilter.IsLessThan(ItemSchema.DateTimeReceived, date.AddDays(1));
	SearchFilter dateFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.And, greaterThanfilter, lessThanfilter);
	//All the mails for the given date is stored in a variable
	var searchResult = exchangeService.FindItems(WellKnownFolderName.Inbox, dateFilter, new ItemView(500));
	//Count of all the mails with date filter is stored in an integer variable
	int mailno = searchResult.Count();
	foreach (Item item in searchResult.Items)
	{
		string sender = ((EmailMessage)(item)).Sender.Name;
		if (sender == "Sender_name")
		{
			//Subject filter criteria
			//A local variable subjectFilter stores the subject filter pattern passed from the database
			//**I want to pass the 'item' into the subjectFilter and bodyFilter**
                        SearchFilter.ContainsSubstring subjectFilter = new SearchFilter.ContainsSubstring(ItemSchema.Subject, item.Subject, ContainmentMode.Substring, ComparisonMode.IgnoreCase);
			//Mail body filter criteria
			//A local variable bodytFilter stores the body filter pattern passed from the database
			SearchFilter.ContainsSubstring bodyFilter = new SearchFilter.ContainsSubstring(ItemSchema.Body, item.Body, ContainmentMode.Substring, ComparisonMode.IgnoreCase);
		}
	}
