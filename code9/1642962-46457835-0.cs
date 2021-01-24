    class NamedObservableCollection : ObservableCollection<ObservableCollection<MyItem>> 
    {  
        public string Name { get; private set;}
    
        public NamedObservableCollection(string name)
        {
            Name = name;
        }
    }
    <ListBox ItemsSource="{Binding Path=MyCollection}" DisplayMemberPath="Name"}/>
