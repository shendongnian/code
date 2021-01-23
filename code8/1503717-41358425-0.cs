        protected override void Seed(ProjectName_DBContext context)
        {
            try
            {
                context.AspNetUsers.Add
                       (
                             new AspNetUser
                             {
                                 Email = "kez@gmail.com",
                                 EmailConfirmed = true,
                                 PasswordHash = "123456",
                                 SecurityStamp = "Author 1st Bio",
                                 PhoneNumber = "0734248148",
                                 PhoneNumberConfirmed = true,
                                 LockoutEndDateUtc = null,
                                 LockoutEnabled = true,
                                 AccessFailedCount = 0,
                                 UserName = "",
                                 FirstName = "",
                                 LastName = "",
                                 CreatedBy = "",
                                 CreatedDate = null,
                                 UpdatedBy = null,
                                 UpdatedDate = null
                             }
                         );
                context.SaveChanges();
                base.Seed(context);
                //context.SaveChanges(); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
