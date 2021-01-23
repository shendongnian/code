    public ActionResult Search(Customer customer)
    {
        var today = DateTime.Today;
        var age = today.Year - this.DateOfBirth.Year;
        if (age < 18)
        {
            // Return an error page or the same page but with error etc.
        }
    
        // All is good
        int id = this.registrar.Register(customer);
    
        // The rest of code
    }
