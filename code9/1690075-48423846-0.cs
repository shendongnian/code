    [HttpPut("{id}")]
    [Route("api/ShoppingCart/UpdateShoppingCartItem")]
    public IActionResult UpdateShoppingCartItem([FromBody]long id)
    {
        return new NoContentResult();
    }
