    public class BusinessesService : IBusinessesService
    {
         public async Task<BusinessResultListModel> Search(BusinessesSearchModel model)
        {
            var queryResult = await _context.YourEntity.Where(x => x.SomeProperty == model.Query).ToListAsync(); //<--- This is your async call, awaiting the ToListAsync() method
            var resultModel = new BusinessResultListModel();
            resultModel.data = queryResult;
            resultModel.othervalue = "other value";
            return resultModel;
        }
    }
