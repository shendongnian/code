        [NotMapped]
        public virtual bool Is_Following { get
            {
                var currentUser = HttpContext.Current.User.Identity.Name;
                if (currentUser == null) return false;
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var userid = db.Users.FirstOrDefault(u => u.UserName == currentUser).Id;
                    if(userid!=null)
                        return db.Followings.Any(u => u.FollowerId == userid && u.UserId == UserId);
                }
                return false;
            }
        }
