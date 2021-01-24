     <ComboBox x:Name="cbxA"
                ItemsSource="{Binding ProjectCategoryList}" 
                SelectedIndex="{Binding Path=SelectedProject.Category}"                      
                DisplayMemberPath="Category"/>
     <ComboBox x:Name="cbxB"
                ItemsSource="{Binding ElementName=cbxA, Path=SelectedItem.Reasons}" 
                DisplayMemberPath="Name" />
     <ComboBox x:Name="cbxC"
          ItemsSource="{Binding ElementName=cbxb, Path=SelectedItem.SubReasons}" />
----------
    public class ProjectCategory
    {
        public string Category { get; set; }
        public IEnumerable<Reason> Reasons { get; set; }
    }
    public class Reason
    {
        public string Name { get; set; }
        public IEnumerable<string> SubReasons { get; set; }
    }
