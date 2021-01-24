    public async Task<bool> ShowYesNoQuestionBox(string userName, string text)
    {
    	var command = new UICommand
    	{
    		CommandType = "yesNo",
    		Message = text,
    		ReturnType = typeof(bool)
    	};
    	
    	return await WebSocketsSingleton.Instance.SendAsync(string userName, command);
    }
