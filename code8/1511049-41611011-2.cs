        switch (sessionDetails.ServiceType)
        {
            case "Provider Service":
               var foo = new ClassName();
               foo.Name = sessionDetails.SessionName;
               foo.OtherClass.StatusId = sessionDetails.subclassfromSessionDetails.SessionStatusId;
               foo.OtherClass.StatusDesc = "Kerfuffle";
               break;
            // More cases here...
        }
