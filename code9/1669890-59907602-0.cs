    protected override void OnViewModelSet()
    {
        base.OnViewModelSet();
        var vm = this.DataContext as SearchMovieViewModel;
        if (vm is null)
        {
            return;
        }
    
        vm.OnViewModelSet();
    }
