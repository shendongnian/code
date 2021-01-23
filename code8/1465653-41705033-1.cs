    //Deserialize
    var result = JsonConvert.DeserializeObject<PaginationEntityStruct<int>>(json);
    StaticPagedList<int> lst = new StaticPagedList<int>(
                        result.Items, 
                        result.MetaData.PageNumber, 
                        result.MetaData.PageSize, 
                        result.MetaData.TotalItemCount);
