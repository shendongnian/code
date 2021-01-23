    await Navigation.PushAsync(new UserJourneysTabPage()); //Push the page you want to push
                var existingPages = Navigation.NavigationStack.ToList(); 
                //get all the pages in the stack
                foreach (var page in existingPages)
                {
                        //Check they type of the page if its not the 
                        //same type as the newly created one remove it
                        if (page.GetType() == typeof(UserJourneysTabPage))
                        continue;
                    Navigation.RemovePage(page);
                }
