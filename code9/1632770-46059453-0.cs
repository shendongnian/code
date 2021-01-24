                ClientApplicationCallWebService.SRMUserRegServiceReference.Customer C = new ClientApplicationCallWebService.SRMUserRegServiceReference.Customer(); 
            C.FirstName = "JOHN";
            C.LastName = "TEST";
            string returnString =ss.GetAllTickets(C);
            Console.WriteLine(returnString); 
