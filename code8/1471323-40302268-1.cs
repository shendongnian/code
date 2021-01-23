      ObservableCollection<Category> categories = new ObservableCollection<Category> { };
      public ListViewContainer()
      {
          this.InitializeComponent();
          categories = new ObservableCollection<Category>
          {
              new Category {Name="name1",details="color1" ,backgroundcolor="#D90015"},
              new Category {Name="name2",details="color2" ,backgroundcolor="#DC1C17"},
              new Category {Name="name3",details="cplor3",backgroundcolor="#DE3A17" },
              new Category {Name="name3",details="color4",backgroundcolor="#E25819" }
          };
      } 
      private void CListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
          var  container = CListView.ContainerFromItem(CListView.SelectedItem);
          ListViewItem item = container as ListViewItem;
          System.Diagnostics.Debug.WriteLine(item.ActualHeight);
      }
