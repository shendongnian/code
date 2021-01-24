    private static void InsertCC(int choice, int qty )
    {
    	if (db2.Query<int>("SELECT 1 FROM CARDCHOICE WHERE CC = ?", choice).Count == 0)
    	{
    		var temp = Enumerable.Range(0, qty).Select(i => new CardChoice { Cc = choice, Number = i });
    		db2.InsertAll(temp);
    	}
    }
