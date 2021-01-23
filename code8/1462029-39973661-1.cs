    <ListView ItemsSource="{Binding }">
                <ListView.Resources>
                    <Style TargetType="ListViewItem">
                        <Style.Triggers>
                            <Trigger Property="IsKeyboardFocusWithin" Value="true">
                                <Setter Property="IsSelected" Value="true" />
                            </Trigger>
                        </Style.Triggers>
                    </Style>
                </ListView.Resources>
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Horizontal">
                            <RadioButton IsChecked="{Binding Choice1}" />
                            <RadioButton IsChecked="{Binding Choice2}" />
                        </StackPanel>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
