    public IPagedList<StageModel> GetStagesPagedList(IQueryable<StageModel> stages, 
        int pageNumber, int pageSize)
    {
         return stages.OrderBy(stage => stage.Name)
             .ToPagedList(pageNumber, pageSize);
    }
