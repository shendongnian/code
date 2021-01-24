    [NotMapped]
    public DateTime? ExpiryDate 
    {
        get
        {
             //of course you'll need some caching here
             var s = context.Database.SqlQuery<string>("query to select datetime as string");
             //additional logic to determine validity:
             if (s == "0000-00-00")
                 return null;
             //else:
             //do the conversion
        }
     }
