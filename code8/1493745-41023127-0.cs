    <ListBox SelectedItem="{Binding SelectedItem}" xmlns:s="clr-namespace:System;assembly=mscorlib">
      <ListBox.ItemContainerStyle>
         <Style TargetType="ListBoxItem">
            <EventSetter Event="PreviewMouseLeftButtonDown" Handler="OnMouseLeftButtonDown"/>
         </Style>
      </ListBox.ItemContainerStyle>
      <s:String>A</s:String>
      <s:String>B</s:String>
      <s:String>C</s:String>
    </ListBox>
    private void OnMouseLeftButtonDown(object sender, MouseEventArgs e)
    {
      ListBoxItem lbi = sender as ListBoxItem;
      if (lbi != null)
      {
        YourViewModel vm = DataContext as YourViewModel;
        if (vm != null)
        {
            var selectedItem = lbi.DataContext as YourObjectType;
            if (vm.SelectedItem == selectedItem)
            {
                vm.SelectedItem = selectedItem;
                e.Handled = false;
            }
        }
      }
    }
