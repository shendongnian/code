      public async Task<SocialListViewModel> GetPagedListAsyncResultSearch(SocialSearchRequestResultSearch request, List<string> fields)
        {
            //Begin Conditions
            var predicate = PredicateBuilder.New<Social>();
            if (request.Id_parvandeh != 0)
            {
                if (request.logic_Id_parvandeh.Equals("And")) predicate = predicate.And(a => a.Id_parvandeh == request.Id_parvandeh);
                else predicate = predicate.Or(a => a.Id_parvandeh == request.Id_parvandeh);
            }
    }
