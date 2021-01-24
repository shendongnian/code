    try
    {
    	//Checks whether the connection is still open
    	var encoding = Encoding.Default;
    	byte[] utf8Bytes = Encoding.Convert(encoding, Encoding.UTF8, encoding.GetBytes(" "));
    	listenerContext.Response.OutputStream.Write(utf8Bytes, 0, utf8Bytes.Length);
    	listenerContext.Response.OutputStream.Flush();
    }
    catch (Exception e)
    {
    	Console.WriteLine(e);
    	eventStream.TriggerEvent(new ActionEventArgs(this, ActionEventStreamer.SYSTEM_CANCEL));
    	break;
    }
