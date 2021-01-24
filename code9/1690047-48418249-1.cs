    <ListBox ItemsSource="{Binding Path=FoldersList.FilesList}"  SelectedItem="{Binding Path=SelectedFolder, Mode=OneWayToSource}">
       <ListBox.ItemTemplate>
           <DataTemplate>
              <StackPanel>
                 <CheckBox IsChecked="{Binding Checked}"/>
                 <Label VerticalAlignment="Stretch" HorizontalAlignment="Stretch" Content="{Binding Path=Path}">
              </StackPanel>
           </DataTemplate>
       </ListBox.ItemTemplate>
    </ListBox>
    
    public class MyFile : INotifyPropertyChanged
    {
        public void SetPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public string Path { get; set; }
        public int Size { get; set; }
        private bool _checked = false;
        public bool Checked
        {
            get {return _checked;}
            set
                {
                   _checked = value;
                   SetPropertyChanged("Checked");
        }
    }
