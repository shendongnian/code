    [ProducesResponseType(typeof(Orders), StatusCodes.Status200OK)]
    public ActionResult<Orders> GetOrders()
    {
        return service.GetOrders();
    }
