    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var context = new DefaultContainer(new Uri("http://services.odata.org/v4/(S(lqbvtwide0ngdev54adgc0lu))/TripPinServiceRW/"));
    
        var person = new Person
        {
            UserName = "russellwhyte",
            FirstName = "Jay",
            LastName = "Zuo"
        };
    
        context.AttachTo("People", person, "*");
    
        context.UpdateObject(person);
    
        await context.SaveChangesAsync();
    
        var personUpdated = await context.People.ByKey("russellwhyte").GetValueAsync();
    
        System.Diagnostics.Debug.WriteLine($"{personUpdated.UserName} : {personUpdated.FirstName} {personUpdated.LastName}");
    }
