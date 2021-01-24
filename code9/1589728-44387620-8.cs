    if (userRepo.IsValid(user))
        {
          userRepo.Add(user); //write this only inside code cause you will always get valid email now.
          // return to different view
        }
        else
        {
          // display userRepo.Message on page
          return View(user);
        }
