    <TreeView.ItemContainerStyle>
          <Style TargetType="{x:Type TreeViewItem}">
               <Setter Property="IsSelected" Value="{Binding IsSelected}" />
          </Style>
    </TreeView.ItemContainerStyle>
    public class MyTreeElement
    {
        private bool _IsSelected;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set 
              { 
                  _IsSelected = value; 
                  OnPropertyChanged("IsSelected");
              }
        }
        private void ElementsCommandMethod(object item)
        {
            Console.WriteLine("ElementsCommand");
            IsSelected = true;
        }
    }
