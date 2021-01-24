    public GoogleCloudDialogflowV2WebhookResponse Post(GoogleCloudDialogflowV2WebhookRequest obj)
        {
                string Location = string.Empty;
    
                switch (obj.QueryResult.Intent.DisplayName)
                {
                    case "getstock":
                    Location = obj.QueryResult.Parameters["Location"].ToString();
                    break;
                }
    
                var response = new GoogleCloudDialogflowV2WebhookResponse()
                {
                    FulfillmentText = $"The stock at {Location} is valuing Rs. 31 Lakhs \n And consists of items such as slatwall, grid and new pillar. The detailed list of the same has been email to you",
                    Source = "API.AI"
                };
    
                return response;
        }
