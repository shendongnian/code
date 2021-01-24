    public List<Invoice> GetUserInvoice()
    {
        int businessId = currentUserBusinessId;// get this line from user Claim.
        return db.Invoices.Where(x=>x.BusinessId == businessId);
    }
