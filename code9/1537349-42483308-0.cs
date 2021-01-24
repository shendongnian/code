    var person = persons.FirstOrDefault(x => x.Id == yourId);
    if (person == null)
    {
      // create new person with subscription
    }
    else
    {
        person.SubscriptionList.Add(subscription)
    }
