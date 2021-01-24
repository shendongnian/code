    this.viewPager = view.FindViewById<ViewPager>(Resource.Id.viewPagerDetails);
    if (viewPager != null)
    {
        var fragments = new List<MvxViewPagerFragmentInfo>();
        fragments.Add(new MvxViewPagerFragmentInfo("Ingredients", "RecipeIngridientsViewModelTag", typeof(RecipeIngridientsView), this.ViewModel.IngridientsViewModel));
        fragments.Add(new MvxViewPagerFragmentInfo("Flavours", "RecipeFlavoursViewModelTag", typeof(RecipeFlavoursView), this.ViewModel.FlavoursViewModel));
        this.viewPager.Adapter = new MvxFragmentPagerAdapter(this.Activity, this.ChildFragmentManager, fragments);
    }
