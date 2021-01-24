    Group _managerGroupName=null; 
        if (clientContext != null)
                            {
                                var siteColl = clientContext.Site;
                                var web = siteColl.RootWeb;
                                GroupCollection groupColl = web.SiteGroups;`
                                
                                clientContext.Load(siteColl);
                                clientContext.Load(web);
                               
                             
    
    
                                clientContext.ExecuteQuery(); 
     
    
        _managerGroupName = web.AssociatedOwnerGroup;
                                    clientContext.Load(_managerGroupName);
                                    clientContext.ExecuteQuery();                  
        UserCollection managerGroupUsers = _managerGroupName.Users;
                clientContext.Load(managerGroupUsers);
                clientContext.ExecuteQuery();
                string[] Username = null;
                foreach (User u in managerGroupUsers)
                {
                    Username = u.Title.Split(' ');
                    string firstName = Username[0];
                    string LastName = Username[1];
     
                }     
