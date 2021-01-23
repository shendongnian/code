     if (DateTime.Now.Hour < 12)
        {
            message="Morning.";
        }
        else if (DateTime.Now.Hour > 12)
        {
            message="Evening.";
        }
        else
        {
            message="Afternoon";
        }
        
