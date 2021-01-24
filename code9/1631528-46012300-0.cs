     foreach(var item in data){
                var c = new apicli  {
                    Email = item.email,
                    Name = item.name,
                    Aff = item.affiliated_id
                    Login = item.account.real.LastOrDefault()?login??"",
                    Login = item.account.real.LastOrDefault()?pass??""
                }
                if(!db.apiclis.Any(a => a.Email == c.Email && a.Name == c.Name && a.Aff == c.Aff)){
                    db.apiclis.Add(c);
                }
            }
