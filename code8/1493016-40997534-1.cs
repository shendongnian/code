    while (true)
    {
    	var SpanList = BodyNode.SelectNodes(".//text:span");
    	var AnySlashesMoved = false;
    	foreach (XmlElement Span in SpanList)
    	{
    		if (Span.InnerText.Contains("/") && Span.InnerXml != "/")
    		{
    			AnySlashesMoved = true;
    			// Create a new span for the slash
    			var SlashSpan = Span.Clone();
    			Span.ParentNode.InsertAfter(SlashSpan, Span);
    			SlashSpan.InnerText = "/";
    			// Create a copy of the original span for the text after the slash
    			var SpanClone = Span.Clone();
    			Span.ParentNode.InsertAfter(SpanClone, SlashSpan);
    			var FirstCNToKeep = -1;
    			for (var I = 0; I < SpanClone.ChildNodes.Count; I++)
    			{
    				var CN = SpanClone.ChildNodes[I];
    				if (CN.NodeType == XmlNodeType.Text && CN.Value.Contains("/"))
    				{
    					CN.Value = CN.Value.Substring(CN.Value.IndexOf("/") + 1);
    					FirstCNToKeep = I;
    					break;
    				}
    			}
    			if (FirstCNToKeep != -1)
    			{
    				for (var I = FirstCNToKeep - 1; I >= 0; I--)
    				{
    					SpanClone.RemoveChild(SpanClone.ChildNodes[I]);
    				}
    			}
    			// Remove the slash and the text after it from the original span
    			var LastCNToKeep = -1;
    			for (var I = 0; I < Span.ChildNodes.Count; I++)
    			{
    				var CN = Span.ChildNodes[I];
    				if (CN.NodeType == XmlNodeType.Text && CN.Value.Contains("/"))
    				{
    					CN.Value = CN.Value.Substring(0, CN.Value.IndexOf("/"));
    					LastCNToKeep = I;
    					break;
    				}
    			}
    			if (LastCNToKeep != -1)
    			{
    				for (var I = Span.ChildNodes.Count - 1; I > LastCNToKeep; I--)
    				{
    					Span.RemoveChild(Span.ChildNodes[I]);
    				}
    			}
    		}
    	}
    	if (AnySlashesMoved == false)
    	{
    		break;
    	}
    }
