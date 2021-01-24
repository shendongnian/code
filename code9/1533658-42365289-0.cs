     [HttpPost]
        public ActionResult Insert(Employee emp)
         {
          if(!ModelState.IsValid)
            {
              return view(emp)
            }
            Employee emp1 = new Employee();
            emp1.insert(emp);
            return View();
         }
