    <ListView ItemsSource="{Binding PropertyControls}">
        <ListView.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Horizontal" Margin="8">
                    <TextBlock Text="{Binding PropertyName}" FontSize="14" Width="400"/>
                    <ContentPresenter Content="{Binding PropertyValue}">
                        <ContentPresenter.Resources>
                            <DataTemplate DataType="{x:Type System:String}">
                                <TextBlock Text="{Binding}"/>
                            </DataTemplate>
                            <DataTemplate DataType="{x:Type System:Bool}">
                                <CheckBox IsChecked="{Binding}"/>
                            </DataTemplate>
                            <!-- ... -->
                        </ContentPresenter.Resources>
                    </ContentPresenter>
                </StackPanel>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
