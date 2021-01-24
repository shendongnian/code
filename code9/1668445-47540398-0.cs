    public async Task<ReturnViewModel> ModContactsAsync(List<ContactsDTO> Contacts)
    {
        ReturnViewModel vm = new ReturnViewModel();
        var postContactsUri = new UriBuilder(AppConfig.ServiceUrlBase);
        postContactsUri.Path = string.Format(POST_CONTACTS_API_PATH, jsonObject);
        //Add Contacts to second parameter
        var response = await _httpClient.PostAsync(postContactsUri.ToString(), Contacts);
    return vm;
}
