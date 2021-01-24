    [HttpGet]
            public ActionResult Details(int id)
            {
                var customer = GetCustomers().SingleOrDefault(x => x.Id == id);
                if (customer == null)
                {
                    return HttpNotFound();
                }
                return View(customer);
            }
