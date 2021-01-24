    public IHttpActionResult PostOwner(OwnerWrapper modelWrapper)
    {
        string productCode = modelWrapper.Product.Code;
        Owner owner = modelWrapper.Owners[0];
        
        return CreatedAtRoute("DefaultApi", new { id = Owner.Id }, owner);
    }
