    public void SeedData()
            {
                using (var serviceScope = scopeFactory.CreateScope())
                {
                    using (var context = serviceScope.ServiceProvider.GetService<ArtCoreDbContext>())
                    {
             if (!context.ApplicationUser.Any())
                      {
                   var user = new ApplicationUser
                            {
                                CityId = context.Cities.Where(g => g.Name == "Abu Nusair").SingleOrDefault().Id,
                                CountryId = context.Countries.Where(g => g.Name == "Jordan").SingleOrDefault().Id,
                                 Email = "maizer85@hotmail.com",
                                FirstName = "Zaid",
                                GenderId = context.Genders.Where(g => g.Name == "Female").SingleOrDefault().Id,
                                IsActive = true,
                                LastName = "Abu Maizar",
                                MaritalStatusId = context.MaritalStatus.Where(g => g.Name == "Single").SingleOrDefault().Id,
                                NationalityId = context.Nationalities.Where(g => g.Name == "Jordanian").SingleOrDefault().Id,
                                OccupationId = context.Occupations.Where(g => g.Name == "MD").SingleOrDefault().Id,
                                 PersonalPhotoUrl = null,
                                 PhoneNumber = "4243244990",
                                 PhoneNumberConfirmed = false,
                                 PostalCode = 91335,
                                 SocialSecurityNo = "AABBCC",
                                StateId = context.States.Where(g => g.Name == "Amman").SingleOrDefault().Id,
                                StatusId = context.Statuses.Where(g => g.Name == "Active").SingleOrDefault().Id,
                                 UserName = "Zaid",
    
                            };
                        Task<IdentityResult> createTask = userManager.CreateAsync(user, "Temp_123");
                        createTask.Wait();
    
                        }
    
                    }
                }
            }
