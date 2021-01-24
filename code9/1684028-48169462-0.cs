    public class MainViewModel : ViewModelBase
    {
       private ObservableCollection<MyDataClass> _myDataList;
    
       public MainViewModel()
       {
          var list = new List<MyDataClass>
          {
             new MyDataClass {Description = "Item 01", Quantity = 20, IsSelected = false},
             new MyDataClass {Description = "Item 02", Quantity = 50, IsSelected = false},
             new MyDataClass {Description = "Item 03", Quantity = 60, IsSelected = false}
          };
    
          MyDataList = new ObservableCollection<MyDataClass>();
    
          foreach (var myDataClass in list)
          {
             MyDataList.Add(myDataClass);
          }
       }
    
       public ObservableCollection<MyDataClass> MyDataList
       {
          get => _myDataList;
          set
          {
             _myDataList = value;
             MyDataList.CollectionChanged += MyDataList_CollectionChanged; // sets up the collection so it will auto-hookup each element
             OnPropertyChanged();
          }
       }
    
       private void MyDataList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
       {
          if (e.NewItems != null)
             foreach (MyDataClass item in e.NewItems)
                item.PropertyChanged += MyData_PropertyChanged;
    
          if (e.OldItems != null)
             foreach (MyDataClass item in e.OldItems)
                item.PropertyChanged -= MyData_PropertyChanged;
    
          OnPropertyChanged(nameof(MyDataList));
       }
    
       private void MyData_PropertyChanged(object sender, PropertyChangedEventArgs e)
       {
          switch (e.PropertyName)
          {
             case nameof(MyDataClass.IsSelected):
                OnPropertyChanged(nameof(Amount));
                break;
          }
       }
    
       public double Amount => MyDataList.Where(x => x.IsSelected).Sum(x => x.Quantity);
    }
