    var fileMetadata = new Google.Apis.Drive.v3.Data.File()
    {
        Name = "Invoices",
        MimeType = "application/vnd.google-apps.folder",
        Description = "Blah blah " + System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second
    };
    Permission perm = new Permission();
    perm.Type = "user";
    perm.EmailAddress = "anotheruser@gmail.com";
    perm.Role = "owner";
    var request = service.Files.Create(fileMetadata);
    request.Fields = "id";
    try 
    {
        service.Permissions.Create(perm, request.Execute().Id).Execute(); //Creating Permission after folder creation.
    }
    catch (Exception e) 
    {
        Console.WriteLine("An error occurred: " + e.Message);
    }
