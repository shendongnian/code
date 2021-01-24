        protected override void OnAppearing()
        {
            base.OnAppearing();
            Navigation.PushModalAsync(new DashboardPage());
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            // move on a different tab to avoid infinite loop when back button is pressed
            var masterPage = this.Parent as TabbedPage;
            masterPage.CurrentPage = masterPage.Children[0];
        }
