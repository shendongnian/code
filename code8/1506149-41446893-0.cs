    var sync = this.SynchronizingObject;
	if (sync != null && sync.InvokeRequired)
		sync.BeginInvoke(new Action(()=> ReceiveEntry(entry), null);
	else                        
	   ReceiveEntry(entry); 
