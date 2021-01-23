      public AnnouncementsViewModel() {
            connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }
      public async void GetAnnouncement() {
            await connection.CreateTableAsync<Announcement>();
            var announcements = await connection.Table<Announcement>().ToListAsync();
            AnnouncementList = new ObservableCollection<Announcement>(announcements);            System.Diagnostics.Debug.WriteLine("***********************************");
            System.Diagnostics.Debug.WriteLine(AnnouncementList.Count);
        }
