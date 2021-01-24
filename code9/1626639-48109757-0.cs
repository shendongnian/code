            peopleRequest.RequestMaskIncludeField = new List<string>() {
                "person.phoneNumbers" ,
                "person.EmailAddresses",
                "person.names"
            };
               
            ListConnectionsResponse people = peopleRequest.Execute();
           
            if (people != null && people.Connections != null && people.Connections.Count > 0)
            {
                foreach (var person in people.Connections)
                {
                    Console.Write(person.Names != null ? (person.Names[0].DisplayName + "  " ?? "n/a") : "n/a  ");
                    Console.Write(person.EmailAddresses?.FirstOrDefault()?.Value + "  ");
                    Console.WriteLine(person.PhoneNumbers?.FirstOrDefault()?.Value);
                }
                if (people.NextPageToken != null)
                {
                    GetPeople(service, people.NextPageToken);
                }
    
