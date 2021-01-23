      protected override async void OnAppearing() {
            (BindingContext as AnnouncementsViewModel).GetAnnouncement();
            if ((BindingContext as AnnouncementsViewModel).list != null)
                classAnnouncementListView.ItemsSource = (BindingContext as AnnouncementsViewModel).list;
            base.OnAppearing();
        }
