    app.UseRouter(r =>
    {
        var contactRepo = new InMemoryContactRepository();
    
        r.MapGet("contacts", GetContacts);
    
        r.MapGet("contacts/{id:int}", GetContact);
    
        r.MapGet("contacts/delete/{id:int}", DeleteContact);
    });
...
    private async Task GetContacts(HttpRequest request, HttpResponse response, RouteData routeData)
    {
        var contact = await contactRepo.Get(Convert.ToInt32(routeData.Values["id"]));
        await response.WriteJson(contact);
    }
    
    private async Task GetContact(HttpRequest request, HttpResponse response, RouteData routeData)
    {
        var contact = await contactRepo.Get(Convert.ToInt32(routeData.Values["id"]));
        await response.WriteJson(contact);
    }
    
    private async Task DeleteContact(HttpRequest request, HttpResponse response, RouteData routeData)
    {
        await contactRepo.Delete(Convert.ToInt32(routeData.Values["id"]));
        var contacts = await contactRepo.GetAll();
        await response.WriteJson(contacts);
    }
