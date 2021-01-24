                    var users = new HashSet<string>();
    //My domain have 4 DC's
                LdapSearchResults searchResults = conn.Search(
                    "CN=Users,DC=z,DC=x,DC=c,DC=v",//You can use String.Empty for all domain search. This is example about users
                    LdapConnection.SCOPE_SUB,//Use SUB
                    "(mail=*@somemail.com)",// Example of filtering with *. You can use String.Empty to query without filtering
                    null, // no specified attributes
                    false // return attr and value
                    );
    
                while (searchResults.hasMore())
                {
                    var nextEntry = searchResults.next();
                    nextEntry.getAttributeSet();
                    var attr = nextEntry.getAttribute("mail");
    
                    if (attr == null)
                    {
                        users.Add(nextEntry.getAttribute("distinguishedName").StringValue);
                    }
                    else {
                        users.Add(nextEntry.getAttribute("mail").StringValue);
                    }
                    
                }
                
