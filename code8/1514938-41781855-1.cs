     public class AuctionController : BaseController<Auction, MobileServiceContext>    
    {        
        public IQueryable<Auction> GetAllAuction()
        {
            return Query(); 
        }
        // GET tables/Auction/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Auction> GetAuction(string id)
        {
            return Lookup(id);
        }
        // PATCH tables/Auction/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Auction> PatchAuction(string id, Delta<Auction> patch)
        {
             return UpdateAsync(id, patch);
        }
        // POST tables/Auction
        public async Task<IHttpActionResult> PostAuction(Auction item)
        {
            Auction current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }
        // DELETE tables/Auction/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteAuction(string id)
        {
             return DeleteAsync(id);
        }
    }
