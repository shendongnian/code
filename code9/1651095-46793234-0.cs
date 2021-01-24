                <DataGrid ItemsSource="{Binding Comments}"              
                      IsReadOnly="True"
                      CanUserAddRows="False"
                      RowStyle="{StaticResource DefaultRowStyle}"
                      SelectedItem="{Binding SelectedComment}"
                      SelectionMode="Single"/>
    public Comment SelectedComment
    public RelayCommand BindToProjectCommand(BindToProject, CanBindToProject)
    public bool CanBindToProject()
    {
         return SelectedComment != null && SelectedComment.ProjectId == null;
    }
