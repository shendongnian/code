    public async Task<List<MeetingContact>> SearchForContact(string search)
    {
        var searchFields = _LyncClient.ContactManager.GetSearchFields();
        var searchResults = await Task<SearchResults>.Factory.FromAsync((ar, o) => _LyncClient.ContactManager.BeginSearch(search, SearchProviders.GlobalAddressList | SearchProviders.ExchangeService, searchFields, SearchOptions.Default, 10, ar, o), _LyncClient.ContactManager.EndSearch, null);
        var searchForContactResults = new List<MeetingContact>();
        if (searchResults == null)
            return searchForContactResults;
        foreach (var searchResult in searchResults.Contacts)
        {
            var contactResult = new MeetingContact
            {
                FullName = searchResult.GetContactInformation(ContactInformationType.DisplayName).ToString(),
                SipAddress = searchResult.Uri
            };
            searchForContactResults.Add(contactResult);
        }
        return searchForContactResults;
    }
