        if (ModelState.IsValid)
        {
            //CustomerDal Dal = new CustomerDal();//REMOVE THIS LINE
            Dal.Customer.Add(obj);     //in memory
            Dal.SaveChanges();          //physical commit 
            return View("Customer", obj);
        }
        else
        { 
            return View("EnterCustomer", obj);
        }
