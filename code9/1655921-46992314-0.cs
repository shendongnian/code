    var service = new PeopleService (new BaseClientService.Initializer()
    {
        HttpClientInitializer = credential,
        ApplicationName = "APP_NAME",
    });
    Person contactToCreate = new Person();
    List<Name> names = new List<Name>();
    names.Add(new Name() {GivenName = "John", FamilyName = "Doe"});
    contactToCreate.Names = names;
    Google.Apis.PeopleService.v1.PeopleResource.CreateContactRequest request =
     new Google.Apis.PeopleService.v1.PeopleResource.CreateContactRequest(service, contactToCreate);
    Person createdContact = request.Execute();
