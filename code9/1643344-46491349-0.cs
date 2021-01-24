    public List<int> GetItemIDs()
        {
            HttpClient client = auth.AuthenticateHTTP(new HttpClient());
            string content = $@"{{""query"": ""Select[System.Id] From WorkItems order by[System.CreatedDate] desc"" }}";
            StringContent stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            string endpoint = "DefaultCollection/_apis/wit/wiql?api-version=1.0";
            Uri requesturl = UriCombine(baseurl, endpoint);
            HttpResponseMessage response = client.PostAsync(requesturl, stringContent).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            var json = Newtonsoft.Json.JsonConvert.DeserializeObject<QueryResponse>(result);
            return json.workItems.Select(x => x.id).ToList();
        }
    public List<string> ListToString200(List<int> ids) //Writes all IDs into comma seperated strings of up to 200 IDs and puts them into a List.
            {
                List<string> idStrings = new List<string>();
    
                if (ids.Count > 200)
                {
                    while (ids.Count > 200)
                    {
                        List<int> t = new List<int>();
                        var IDs = ids.Take(200);
                        ids.Remove(200);
                        foreach (var item in IDs)
                        {
                            t.Add(item);
                        }
    
                        var ID = t.ConvertAll(element => element.ToString()).Aggregate((a, b) => $"{a},{b}");
                        idStrings.Add(ID);
                    }
                }
                else if (ids.Count > 0)
                {
                    var ID = ids.ConvertAll(element => element.ToString()).Aggregate((a, b) => $"{a}, {b}");
                    idStrings.Add(ID);
                }
    
                return idStrings;
            }
    
    
    private List<WorkItem> GetAllWorkItems()
            {
                List<int> ids = GetItemIDs();
                List<WorkItemsContainer> Responses = new List<WorkItemsContainer>();
                List<WorkItem> ResultList = new List<WorkItem>();
    
                List<string> idStrings = ListToString200(ids);
    
                using (HttpClient client = new HttpClient())
                {
                    auth.AuthenticateHTTP(client);
    
                    foreach (var item in idStrings)
                    {
                        WorkItemsContainer WorkItem = new WorkItemsContainer();
    
                        string featurePath = $"DefaultCollection/_apis/wit/workitems?ids={item}&$expand=all&api-version=1.0";
                        Uri requestUri = Authenticator.UriCombine(baseurl, featurePath);
                        HttpResponseMessage response = client.GetAsync(requestUri).Result;
                        string result = response.Content.ReadAsStringAsync().Result;
                        result = result.Replace("System.", "System");
    
                        WorkItem = JsonConvert.DeserializeObject<WorkItemsContainer>(result);
                        Responses.Add(WorkItem);
                    }
                }
    
                foreach (var item in Responses)
                {
                    foreach (var x in item.value.ToList<WorkItem>())
                    {
                        WorkItemsToJsonFile(x);
                        ResultList.Add(x);
                    }
                }
                return ResultList;
            }
