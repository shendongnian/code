    void Main()
    {
        // Testing mocked data
    	var data = new List<ServerMessagePart> {
    		new ServerMessagePart{
    			Messagenumber = "0529069f-a403-4eea-a955-430a10995745",
    			Message= "A",
    			Partnumber= 1,
    			Total = 3
    		},
    		new ServerMessagePart{
    			Messagenumber = "0529069f-a403-4eea-a955-430a10995745",
    			Message= "C",
    			Partnumber= 3,
    			Total = 3
    		},
    		new ServerMessagePart{
    			Messagenumber = "0529069f-a403-4eea-a955-430a10995745",
    			Message= "B",
    			Partnumber= 2,
    			Total = 3
    		},
    		new ServerMessagePart{
    			Messagenumber = "52e7d68d-462b-46b9-8eec-f289bcdf7b06",
    			Message= "AA",
    			Partnumber= 1,
    			Total = 2
    		}
    	};
    	
    	// Compiled messages
    	var messages = new List<ServerMessage>();
    	
    	// Process server partial messages - group parsts by message number
    	var partialMessages = data.GroupBy(x => x.Messagenumber);
    	foreach(var messageParts in partialMessages) {
    	
    		// Get expected parts number
    		var expected = messageParts.Max(x=>x.Total);
    
    		// Skip incompleted messages
    		if(messageParts.Count() < expected) {
    			continue;
    		}
    		
    		// Sort messages and compile the message
    		var message = messageParts.OrderBy(x => x.Partnumber).Select(x => x.Message).Aggregate((x,y) => x + y);
    		
    		// Final message
    		messages.Add(new ServerMessage{
    			Messagenumber = messageParts.First().Messagenumber,
    			Message = message
    		});
    	}
    	
    	// Final messages
    }
    
    class ServerMessage {
    	public string Messagenumber {get; set;}
    	public string Message {get; set;}
    }
    
    class ServerMessagePart {
    	public string Messagenumber {get; set;}
    	public string Message {get; set;}
    	public int Partnumber {get; set;}
    	public int Total {get; set;}
    }
