     var selectedArticles =
              vm.Articles.Except(
                    vm.Articles.Where(
                       x => x.Quantity == 0 || 
                       x.HideUntilDate == null || 
                       x.HideUntilDate < DateTime.Now.Date()
                   )
              ).ToList();
