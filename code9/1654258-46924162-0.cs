    public WriteResult CreateInspection(Customer customer)
    {
        SalesforceId = customer.SalesforceId;
        CustomerId = customer.Id;
        //Customer = customer;
        return InspectionService.CreateInspection(this);
    }
