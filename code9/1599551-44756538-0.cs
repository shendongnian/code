    <xt:DropDownButton Content="Elements Selection" VerticalAlignment="Top" HorizontalAlignment="Left" MinWidth="100">
        <xt:DropDownButton.DropDownContent>
            <ListView ItemsSource="{Binding Elements}" SelectionMode="Multiple" MinWidth="100">
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <CheckBox IsChecked="{Binding IsSelected, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged, RelativeSource={RelativeSource AncestorType=ListViewItem}}">
                            <CheckBox.Content>
                                <TextBlock Text="{Binding Caption}"/>
                            </CheckBox.Content>
                        </CheckBox>
                    </DataTemplate>
                </ListView.ItemTemplate>
                <ListView.ItemContainerStyle>
                    <Style TargetType="ListViewItem">
                        <Setter Property="IsSelected" Value="{Binding IsSelected, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"/>
                    </Style>
                </ListView.ItemContainerStyle>
            </ListView>
        </xt:DropDownButton.DropDownContent>
    </xt:DropDownButton>
