    public async Task<List<long?>> updateCampaign(List<Campaign> campaigns)
        {
            try
            {
                var listBulkCampaign = new List<BulkCampaign>();
                foreach (var campaign in campaigns)
                {
                  var _bulkCampaign = new BulkCampaign()
                    {
                        Campaign = campaign
                    };
                    listBulkCampaign.Add(_bulkCampaign);
                }
                BulkServiceManager bulkServiceManager = new BulkServiceManager(_authorizationData);
                string fileName = bingCampaignUpdate.csv;
                var campaigns = (await bulkServiceManager.UploadEntitiesAsync(new EntityUploadParameters
                {
                    Entities = listBulkCampaign,
                    OverwriteResultFile = true,
                    ResultFileDirectory = FileDirectory,
                    ResultFileName = fileName,
                    ResponseMode = ResponseMode.ErrorsAndResults
                })).OfType<BulkCampaign>().ToList();
                return new List<long?>();
            }
            catch (Exception ex)
            {
                ErrorLog.log(ex);
                return new List<long?>();
            }
    }
