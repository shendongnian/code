     public async Task<BusinessResultListModel> Search(BusinessesSearchModel model)
    {
        //something like:
        var queryResult = await (from b in MyDBContext.Businesses
                            where b.Name.Contains(model.Name)
                            && b.Phone.Contains(model.Phone)
                            select new BusinessesListModel
                            {
                                ID = b.ID,
                                Name = b.Name,
                                Phone = b.Phone
                            }
                            ).ToListAsync();
        var resultModel = new BusinessResultListModel();
        resultModel.data = queryResult;
        resultModel.othervalue = "other value";
        return resultModel;
    }
