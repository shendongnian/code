    <ListBox ScrollViewer.VerticalScrollBarVisibility="Disabled" SelectionMode="Extended" ItemsSource="{Binding ProccessFilter}">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <CheckBox IsChecked="{Binding IsChecked, Mode=TwoWay}" Content="{Binding Text}"/>
            </DataTemplate>
        </ListBox.ItemTemplate>
        <ListBox.ItemContainerStyle>
            <Style TargetType="{x:Type ListBoxItem}">
                <Setter Property="IsSelected" Value="{Binding IsChecked, Mode=TwoWay}"/>
            </Style>
        </ListBox.ItemContainerStyle>
        <ListBox.ItemsPanel>
            <ItemsPanelTemplate>
                <WrapPanel Orientation="Vertical"/>
            </ItemsPanelTemplate>
        </ListBox.ItemsPanel>
    </ListBox>
