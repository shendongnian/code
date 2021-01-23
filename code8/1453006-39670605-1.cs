    var rName_Add_User_result = " Strong ";
    //List<string> users = dbm.FindManagers();
    var users = new List<string>() {"Facebook", "Google", "Yahoo", "Strongman", "Zombies", "Stratovarius"};
    foreach (var Existed in users.Where(u => u.ToUpper().Contains(rName_Add_User_result.ToUpper().Trim()))
    {
         //dbm.AddSubuser(Existed, rName_result);
         Console.WriteLine(Existed);
    }
