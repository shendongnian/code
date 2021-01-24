    <ContentControl DataContext="{Binding ViewModels}" Content="{Binding Path=CurrentlySelectedComboBoxViewModel}">
      <ContentControl.Resources>
         <DataTemplate DataType="{x:Type vm:TypeAViewModel}">
            <StackPanel>
               <local:TypeAUserControl />
               </StackPanel>
         </DataTemplate>
    
         <DataTemplate DataType="{x:Type vm:TypeBViewModel}">
            <StackPanel>
               <local:TypeBUserControl />
            </StackPanel>
         </DataTemplate>
      </ContentControl.Resources>
    </ContentControl>
