    var range = new UniqueIdRange(new UniqueId((uint) msgIdx),    UniqueId.MaxValue);
   
    var items = inbox.Fetch(uids, MessageSummaryItems.UniqueId | MessageSummaryItems.Envelope);
    foreach(var item in items)
    {
    	LblMessage.Text += item.UniqueId + " Subject:" + item.Envelope.Subject + "<br/>";
    }
