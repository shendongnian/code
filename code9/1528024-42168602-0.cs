                <wpfTool:DropDownButton Content="Options">
                    <wpfTool:DropDownButton.DropDownContent>
                        <ListView Margin="0" ItemsSource="{Binding MyOptions}">
                            <ListView.ItemTemplate>
                                <DataTemplate>
                                    <CheckBox Content="{Binding DisplayName}" IsChecked="{Binding IsChecked, Mode=TwoWay}" />
                                </DataTemplate>
                            </ListView.ItemTemplate>
                        </ListView>
                    </wpfTool:DropDownButton.DropDownContent>
                </wpfTool:DropDownButton>
