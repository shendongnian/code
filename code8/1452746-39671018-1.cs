    public class MainWindowViewModel : BindableBase
        {
            public ObservableCollection<object> Items { get; } =
                new ObservableCollection<object>(new List<object>(new List<object>
            {
                new ParentEntity { UID = 1, Name = "Groop1" },
                new ChildEntity { ParentUID = 1, Name = "Item1" },
                new ParentEntity { UID = 2, Name = "Groop2" },
                new ChildEntity { ParentUID = 2, Name = "Item1" },
                new ChildEntity { ParentUID = 2, Name = "Item2" },
                new ChildEntity { ParentUID = 2, Name = "Item3" }
            }));
    
            public CollectionView RootItems { get; }
    
    
            int count = 2;
            public DelegateCommand AddRoot { get; }
    
            public DelegateCommand<ParentEntity> AddLeafe { get; }
            public MainWindowViewModel()
            {
                RootItems = new ListCollectionView(Items) { Filter = (item) => item is ParentEntity }; 
    
                AddRoot = new DelegateCommand(() =>
                {
                    Items.Add(new ParentEntity { UID = ++count ,Name= "Group"+count});
                });
    
                AddLeafe = new DelegateCommand<ParentEntity>((pe) =>
                {
                    Items.Add(new ChildEntity { ParentUID = pe.UID, Name = "Item" + count });
                });
    
            }
    
        }
    
        public class ParentEntity
        {
            public int UID { get; set; }
            public string Name { get; set; }
        }
    
        public class ChildEntity
        {
            public int ParentUID { get; set; }
            public string Name { get; set; }
            public int Value { get; set; }
        }
    
        public class ItemTemplateSelector : DataTemplateSelector
        {
            public override DataTemplate
                SelectTemplate(object item, DependencyObject container)
            {
                FrameworkElement element = container as FrameworkElement;
    
                if (item is ParentEntity)
                {
                    return element.FindResource("ParentEntityTemplate") as DataTemplate;
                }
                if (item is ChildEntity)
                {
                    return element.FindResource("ChildEntityTemplate") as DataTemplate;
                }
                return null;
            }
        }
    
        public class HierarchicalDataConverter : IMultiValueConverter
        {
            public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value[0] != null)
                {
                    ParentEntity pe = value[0] as ParentEntity;
                    var items = value[1] as IEnumerable<object>;
                    
                    return items.Where((item) => item is ChildEntity && (item as ChildEntity).ParentUID == pe.UID);
                }
                return null;
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
