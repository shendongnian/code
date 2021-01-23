    ...
                else
                {
                    contactObj = new contactObj()
                    {
			            Id = 10,
                        FirstName = "John";
                        LastName = "Smith";
                    };
                    dbContext.Contact.Add(contactObj);
                }
