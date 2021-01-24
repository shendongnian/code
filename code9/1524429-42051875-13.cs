    public IActionResult Get()
    {
      IList<Product> products = _service.GetProducts(currentUserRole);
      return Ok(products);
    }
 
