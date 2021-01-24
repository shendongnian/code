    public ActionResult GenerateNumbers( User user)
        {
            Random rand = new Random();
            int numero = rand.Next(10000, 99999);
            var nuevoCodigo = new User
            {
                Name = user.Name,
                Code = numero,
            };
            db.Users.Add(nuevoCodigo);
            //You should commit your context here also  
            return View(db.Users); // Pass user list as your model to view
    }
