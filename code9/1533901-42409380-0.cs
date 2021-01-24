	CurrentPage.FindByName<Entry>("FirstEntry").Completed += (o, args) =>
	{
		CurrentPage.FindByName<Entry>("SecondEntry").Focus();
	};
	CurrentPage.FindByName<Entry>("SecondEntry").Completed += (o, args) =>
	{
		CurrentPage.FindByName<Entry>("ThirdEntry").Focus();
	};
	CurrentPage.FindByName<Entry>("ThirdEntry").Completed += (o, args) =>
	{
		CurrentPage.FindByName<Entry>("ForthEntry").Focus();
	};
	CurrentPage.FindByName<Entry>("ForthEntry").Completed += (o, args) =>
	{
		CurrentPage.FindByName<Entry>("FifthEntry").Focus();
	};
	CurrentPage.FindByName<Entry>("FifthEntry").Completed += (o, args) =>
	{
		//Keep going or execute your command, you got the drill..
	};  
