    var allCategories = categoryRepository
                                    .Categories
                                    .Select(x => new
                                    {
                                        x.CategoryID,
                                        x.FriendlyName,
                                        x.RoutingName,
                                        x.ParentID
                                    })
                                    .ToList();
                var allListings = listingRepository
                                  .Listings
                                  .Where(x => x.Lister.Status != Subscription.StatusEnum.Cancelled.ToString())
                                  .Select(x => new
                                  {
                                      x.SelectedCategoryOneID,
                                      x.SelectedCategoryTwoID,
                                      x.SelectedCategoryThreeID,                                      
                                  })
                                  .ToList();
                categories = 
                allCategories
               .Where(x => x.ParentID == null)
               .Select(a => new CategoryBrowseIndexViewModel
               {
                   CategoryID = a.CategoryID,
                   FriendlyName = a.FriendlyName,
                   RoutingName = a.RoutingName,
                   ListingCount = allListings
                                  .Where(x => x.SelectedCategoryOneID == a.CategoryID)
                                  .Count(),
                   BrowseCategoriesLevelTwoViewModels = 
                        allCategories
                        .Where(x => x.ParentID == a.CategoryID)
                        .Select(b => new BrowseCategoriesLevelTwoViewModel
                        {
                            CategoryID = b.CategoryID,
                            FriendlyName = b.FriendlyName,
                            RoutingName = b.RoutingName,
                            ParentRoutingName = a.RoutingName,
                            ListingCount = allListings
                                           .Where(x => x.SelectedCategoryTwoID == b.CategoryID)
                                           .Count(),
                            BrowseCategoriesLevelThreeViewModels = 
                                allCategories
                                .Where(x => x.ParentID == b.CategoryID)
                                .Select(c => new BrowseCategoriesLevelThreeViewModel
                                {
                                    CategoryID = c.CategoryID,
                                    FriendlyName = c.FriendlyName,
                                    RoutingName = c.RoutingName,
                                    ParentRoutingName = b.RoutingName,
                                    ParentParentID = a.CategoryID,
                                    ParentParentRoutingName = a.RoutingName,
                                    ListingCount = allListings
                                                   .Where(x => x.SelectedCategoryThreeID == c.CategoryID)
                                                   .Count()
                                })
                                .OrderBy(x => x.FriendlyName)
                        })
                        .OrderBy(x => x.FriendlyName)
               })
               .OrderBy(x => x.FriendlyName == jobVacanciesFriendlyName)
               .ThenBy(x => x.FriendlyName == servicesLabourHireFriendlyName)
               .ThenBy(x => x.FriendlyName == goodsEquipmentFriendlyName);
