    var currentUserId = HttpContext.Current.User.Identity.GetUserId();
            var context = new ApplicationDbContext();
            var user = context.Users.FirstOrDefault(u => u.Id == currentUserId);
            if (user != null)
            {
                if (FirstName.Text != "")   user.FirstName = FirstName.Text;
                if (LastName.Text != "")    user.LastName = LastName.Text;
                if (PhoneNumber.Text != "") user.PhoneNumber = PhoneNumber.Text;
                if(Email.Text != "")        user.Email = Email.Text;
                
            }            
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var result = userManager.Update(user);
            context.SaveChanges();
