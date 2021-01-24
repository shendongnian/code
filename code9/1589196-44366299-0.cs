    [HttpPost]
    [Route("GetUpdatedPrice/{pDate:datetime}")]
    public  ServiceProviderDocuments GetUpdatedPrice(DateTime pDate)
    {
        return ServiceProviderDocumentsGateway.GetUpdatedPriceofBike(pDate);
    }
