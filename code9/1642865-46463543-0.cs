     public ActionResult UpdatePerson(List<Person> Proucts)
        {
            var dbProductsList = GetProducts(); //Get Product List
            foreach (var product in Proucts)
            {
                if (!dbProductsList.Where(x => x.Name == product.Name).Any())
                {
                    dbContext.Update(product);
                    dbContext.SaveChanges();
                }
            }
            return View();
        }
