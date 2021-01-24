    [Route("~/CKService.svc/author/add")]
    [HttpPost]
    public IHttpActionResult AddProduct(ProductRequest request) {
        var status = ProductManager.AddProduct(request.ProductId, request.ProductName, request.Price);
        var response = new AddProductResponse() {
            Status = status
        };
        if(status == AddProductStatus.Success) {
            return Ok(response);
        }
        return BadRequest(response);
    }
