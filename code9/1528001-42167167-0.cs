    private static async Task LogCloudModel(ModelExecutionContext context)
         {
            var azureStorageAccount = new AzureStorageAccount();
            var cloudModelDetail = new CloudModelDetail();
    
            //Populate the cloud model
            var cloudModelDetailCollection = PopulateCloudModel(context, cloudModelDetail);
    
            if (cloudModelDetailCollection == null) return;
            await InsertIntoTableStorage(azureStorageAccount, cloudModelDetailCollection);
            LogTableStorageTransactionResult(azureStorageAccount, operationResult, cloudModelDetail.PartitionKey, cloudModelDetail.RowKey);
          }
