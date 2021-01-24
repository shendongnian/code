    [Route("{countryId}")]
    public IHttpActionResult Delete(int countryId)
    {
        try
        {
           repoCountry.DeleteCountry(countryId);
        }
        catch (RepoException ex)
        {
           if (ex == notfound)
              this.NotFound();
           if (ex == cantdelete)
              this.Confict();
           this.InternalServerError(ex.message);
        }
        return this.Ok();
    }
 
