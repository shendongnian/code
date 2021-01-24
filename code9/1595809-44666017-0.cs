    navigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                if (e.MenuItem.ItemId == Resource.Id.nav_MGrade)
                {
                    MGradeFragment mg = new MGradeFragment();
                    // The fragment will have the ID of Resource.Id.fragment_container.
                    ft.Replace(Resource.Id.ll, mg);
                }
                else if(e.MenuItem.ItemId == Resource.Id.home)
                {
                    //...
                }
                //...
                // Commit the transaction.
                ft.Commit();
                drawerLayout.CloseDrawers();
            };
