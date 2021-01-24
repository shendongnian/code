    public class OrdersController : ODataBaseController
    {
        [EnableQuery]
        public IHttpActionResult Get(ODataQueryOptions<Order> options)
        {
            try
            {
                options.Validate(settings);
                return Ok(dbContext.Orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
}
