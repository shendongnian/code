     [Route("api/myApiMethod")]
        public Response<DomainModel> GetSectorSummaryData(int ID)
        {
        	try
        	{
        		DomainModel	myDomainModel	= new DomainModel(ID);
        		return new Response<DomainModel>(myDomainModel);
        	}
        	catch (Exception ex)
        	{
        		return new Response<DomainModel>(ex);
        	}
        }
