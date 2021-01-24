    [BindProperty]
    public RootObject dataList { get; set; }
                        
    var jsonAsString = customIndexModel.ApiResponseMessage.Content.ReadAsStringAsync().Result;
    dataList = JsonConvert.DeserializeObject<RootObject>(jsonAsString);
         
