    @{ 
        String topic ;
    
        topic = Request.QueryString.GetValues(0)[0] ;
    
        if (topic.Equals("Dash"))
        { 
            //HTML code 
        }
        else if (topic.Equals("Manage"))
        {
            //HTML code2
        }
    }
