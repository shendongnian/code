    private async void OnListSelected(object sender, EventArgs e) {
        StatusBarIsVisibile = true; 
        ThisList = await buildBnBList(SelectedList, selectedLocation, thisYearList.ListId);
    
        StatusBarIsVisibile = false;
        ThisList.MainVM = this;
        ThisList.BuildView();
        PIShowListHeaderText = SelectedList.Title.Trim();
    }
