    protected int? GetTotal(LdapSearchResults searchResult)
    {
        searchResult.Guard(nameof(searchResult));
        if (searchResult.ResponseControls != null && searchResult.ResponseControls.Any())
        {
            foreach (LdapControl control in searchResult.ResponseControls)
            {
                if (control.ID == "2.16.840.1.113730.3.4.10") // the id of the response control
                {
                    LdapVirtualListResponse response =
                        new LdapVirtualListResponse(control.ID, control.Critical, control.getValue());
                    return response.ContentCount;
                }
            }
        }
    
        return null;
    }
