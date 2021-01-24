     Vendor[] vendors = new Vendor[]
     {
        new Vendor() // first vendor
        {
           CardName="Vendor1",
           WebsiteLink="www.vendor1.com",
           PartnerSince=DateTime.Parse("10-10-2012"), 
           SupportNo="521-586-8956",
           SupportEmail="nikki@vendor1.com",
           Reps = new List<Rep>()
           {
               new Rep() // first rep
               {
                  RepName = "name",
                  RepPosition = "pos",
                  RepNo = "no",
                  RepEmail = "email"
               }
               // , new Rep(){...}  // second rep, etc...
           }
        }
        // , new Vendor(){....}    // second vendor, etc...    
     };
