    public override bool OnOptionsItemSelected(IMenuItem item)
    {
        var app = Application.Current;
        if (item.ItemId == 16908332) // This makes me feel dirty.
        {
            var navPage = ((app.MainPage.Navigation.ModalStack[0] as MasterDetailPage).Detail as NavigationPage);
            if (app != null && navPage.Navigation.NavigationStack.Count > 0)
            {
                int index = navPage.Navigation.NavigationStack.Count - 1;
                var currentPage = navPage.Navigation.NavigationStack[index];
                var vm = currentPage.BindingContext as ViewModel;
                if (vm != null)
                {
                    var answer = vm.OnBackButtonPressed();
                    if (answer)
                        return true;
                }
            }
        }
        return base.OnOptionsItemSelected(item);
    }
