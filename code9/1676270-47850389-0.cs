	public void Main()
	{
		DoExcelWork();
		GC.Collect();
		GC.WaitForPendingFinalizers();
	}
	private void DoExcelWork()
	{
		Application app = null;
		Workbooks books = null;
		Workbook book = null;
		try
		{
			app = new Application() { DisplayAlerts = false };
			books = app.Workbooks;
			book = books.Open("filename goes here");
			book.RefreshAll();
            // this is where you would do your Excel work
			app.DisplayAlerts = false; // This is for reinforcement; the setting has been known to reset itself after a period of time has passed.
			book.SaveAs("save path goes here");
			app.DisplayAlerts = true;
			book.Close();
			app.Quit();
		}
		catch ()
		{
			if (book != null) book.Close(SaveChanges: false);
			if (app != null) app.Quit();
		}
	}
