    <ItemsControl ItemsSource="{Binding DutyValueBinders}" IsEnabled="{Binding Enabled}"
                  PreviewKeyDown="ItemsControl_PreviewKeyDown">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <StackPanel Orientation="Horizontal"/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <TextBox Text="{Binding Value, TargetNullValue=''}"  Width="50"></TextBox>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
----------
    private void ItemsControl_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            TextBox textBox = Keyboard.FocusedElement as TextBox;
            if (textBox != null)
            {
                textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }
    }
