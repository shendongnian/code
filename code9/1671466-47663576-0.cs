    // Static field or whatever you want
    Dictionary<string, Action<string>> methods = new Dictionary<string, Action<string>>()
    {
    	{ "extractDataOne", ExtractMethodOne },
    	{ "extractDataTwo", ExtractMethodTwo },
    	{ "extractDataThree", ExtractMethodThree },
    	{ "extractDataFour", ExtractMethodFour },
    	{ "extractDataFive", ExtractMethodFive },
    };
    
    // And then use it like this
    methods[markup[fileMarkup].Item3].Invoke(fileMarkupValues);
