    try
	{
	  if (OperationContext.Current.GetCallbackChannel<ITimeRecordingClient>() != con)
	  {
	    con.StopTimer(kvp.Key);
	  }
    }
	catch { }
