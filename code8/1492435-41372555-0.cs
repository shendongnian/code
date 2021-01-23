     PasswordVault vault = new PasswordVault();
     vault.Add(new PasswordCredential(key, login, password));
     var collection = vault.FindAllByResource(key).ToList();
     foreach (var item in collection)
     {
         item.RetrievePassword();
         var password = item.Password;
         Debug.WriteLine(password);
     }
