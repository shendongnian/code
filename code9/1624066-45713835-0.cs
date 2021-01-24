    public async Task<IHttpActionResult> Delete(int customerId, int materialCustomerId)
    {
        await _materialCustomerDeleter.DeleteAsync(MaterialCustomer.CreateWithOnlyId(materialCustomerId), HttpContext.RequestAborted);
        return Ok();
    }
