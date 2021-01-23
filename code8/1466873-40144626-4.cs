	TransactionChangeLog changeLog = JsonConvert.DeserializeObject<TransactionChangeLog>(json);
	Console.WriteLine("TransactionId: " + changeLog.TransactionId);
	Console.WriteLine("TransactionStatus: " + changeLog.Status);
	foreach (TransactionChange change in changeLog.Changelog)
	{
	    Console.WriteLine(change.ChangeDate + " - changed " + change.Field + " from '" + change.From + "' to '" + change.To + "'");
	}
