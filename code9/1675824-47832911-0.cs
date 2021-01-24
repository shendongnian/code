            [Route("~/Prop/{StateInformed?}")]
            public ActionResult Test(string StateInformed = null)
            {
                // DO STAFF
    
                return View();
            }
            [HttpPost]
            [Route("~/Prop/{StateInformed?}")]
            public ActionResult Test(int? idState)
            {
                // DO STAFF
    
                String state = string.Empty;
    
                if (idState.HasValue)
                {
                state = "MyState";
                }
    
                // if state is null the route will be "/Prop" else "/Prop/MyState"
                return RedirectToAction("Test", new { StateInformed =state});
            }
