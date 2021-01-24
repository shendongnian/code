    public ActionResult GenerateNumbers(User user)
    {
        Random rand = new Random();
        int numero = rand.Next(1, 100000);
        var nuevoCodigo = new User
        {
            Name = user.Name,
            Code = numero       
        };
    
        using (var db = new UserEntities())
        {
            db.Users.Add(nuevoCodigo);
            db.SaveChanges();
        }
    
        // return view page with assigned viewmodel properties
        return View(nuevoCodigo);
    }
