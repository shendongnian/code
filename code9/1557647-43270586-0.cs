            SearchRequest searchRequest = new SearchRequest();
            searchRequest.DistinguishedName = strGroupDN;
            searchRequest.Filter = String.Format("(&(objectCategory=Group)(CN={0}))", strGroupDN.ToString().Split('=')[1].Split(',')[0]);
            SearchResponse response =
      (SearchResponse)ldap.SendRequest(searchRequest);
            if (response != null && response.Entries.Count > 0)
            {
                SearchResultEntry obj = response.Entries[0];//I get group object here
                if (obj.Attributes["member"] != null)
                {
                    
                    var childCount = ((System.Collections.CollectionBase)(obj.Attributes["member"])).Count;
                  
                    for (int i = 0; i < childCount; i++)
                    {
                        string groupName = obj.Attributes["member"][i].ToString();//I get all members in which i have to find subgroups
                        List<string> localGroupList = new List<string>();
                        if (groupName.Contains("OU=Groups"))
                        {
                            var attributes = obj.Attributes.AttributeNames;
                            string attributesstr = string.Empty;
                            foreach (var item in attributes)
                            {
                                attributesstr = attributesstr + "," + item;
                            }
                            _subGroupList.Add(groupName.ToString().Split('=')[1].Split(',')[0] + "  :  " + attributesstr);
                            count_Children++;
                           
                        }
                       
                    }
                 
                }
            }
        }
