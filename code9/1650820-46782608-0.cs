    public ActionResult GenerateNumbers( User user)
    {
      //first approach
      var nuevoCodigo = new User
      {
        Name = user.Name,
        Code = GenerateCode()    
      };
      //second approach
      var nuevoCodigo = new User
      {
        Name = user.Name
        Code =GenerateCode(5)
      };
      db.Users.Add(nuevoCodigo);
      return View(db.Users);
    }
    private int GenerateCode()
    {
      Random rand = new Random();
      return rand.Next(10000, 99999);//change 10000 to 1 if code should be 1 digit
    }
    public int GenerateCode(int length)
    {
       Random random = new Random();
       const string chars = "0123456789";
       string code =  new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
       return Convert.ToInt32(code);
    }
