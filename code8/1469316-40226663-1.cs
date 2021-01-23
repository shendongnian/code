    [HttpPost]
    [Route("api/Cart/{cartItemId}")]
    [ResponseType("200", typeof(ResponseObject<CartItemDomainModel>)), ResponseType("500", typeof(Exception))]
    public async Task<IHttpActionResult> UpdateQuantity(int cartItemId, [FromBody]int quantity)
    {
        var result = await _cartService.UpdateCartItemQuantity(cartItemId,quantity));
    
        return ...;
    }
