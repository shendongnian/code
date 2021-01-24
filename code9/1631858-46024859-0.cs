       [HttpGet]
       public IActionResult ListProducts() { ... }
    
       [HttpGet("{id}")]
       public ActionResult GetProduct(int id) { ... }
    }
