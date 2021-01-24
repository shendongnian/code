    @{
    	Func<dynamic, object> phoneformat = (item) =>
    		{
                // if we have a string
    			if (item is String && !String.IsNullOrEmpty(item))
    			{
                    // check if the first is not a 0
    				if (item[0] != '0')
    				{
                        // add it
    					item = String.Format("0{0}", item);
    				} 
    			}
    			else if(item is Int32)
    			{
                    /// ints never have leading 0, so add it
    				item = String.Format("0{0}", item);
    			}
    			return item;
    		};
    }
    <a href="tel:0@(Model.Work.Phone)">0@(Model.Work.Phone)</a> <br/>
    <a href="tel:0@(Model.Work.PhoneInt)">0@(Model.Work.PhoneInt)</a>
    
    <a href="tel:@phoneformat(Model.Work.Phone)">@phoneformat(Model.Work.Phone)</a> <br/>
    <a href="tel:@phoneformat(Model.Work.PhoneInt)">@phoneformat(Model.Work.PhoneInt)</a>
