    public void UpdateCurrentTab()
    {
        ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
        int currentItem = viewPager.CurrentItem;
        Snackbar.Make(drawerLayout, "CALL TO UPDATE Tab " + currentItem, Snackbar.LengthLong).Show();
        View fView = viewPager.GetChildAt(currentItem);
        if (currentItem == 1) 
        { 
            // Now it's a type's method not object's
            tabFragment1.UpdateContent(fView); 
        }
    }
