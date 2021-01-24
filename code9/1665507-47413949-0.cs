    private async Task GeneratePage() {
      List<Folder> folders = await ApiManager.GetFoldersAsync();
      foreach (var f in folders) {
        List<Lists> lists = new List<Lists>();
        foreach (int id in f.list_ids) {
          lists.Add(await ApiManager.GetSpecificListAsync(id));
          // Debug.WriteLine("ID for list '"+ f.title +"' : " + id);
        }
        ListView listView = new ListView {
          ItemsSource = lists
        };
        listView.ItemTapped += ListViewOnItemTapped;
        this.Children.Add(new ContentPage {
          Title = f.title,
          Content = listView
        });
      }
    }
    private void ListViewOnItemTapped(object sender, ItemTappedEventArgs itemTappedEventArgs) {
      throw new NotImplementedException();
    }
