       [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {   
                //if you want to get validation message from ModelState itself, you can query from Modelstate :
               string message = string.Join(" , ", ModelState.Values
                                  .SelectMany(v => v.Errors)
                                   .Select(e => e.ErrorMessage));
                ViewData["ValidationMessage"] = "Validation Message";// you can use above variable message here
                return View(product);
            }
         // your other implementation
        }
