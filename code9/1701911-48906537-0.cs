    <ListView.ItemTemplate>
        <DataTemplate>
            <StackPanel Background="#FF3C3C3C"
                        DockPanel.Dock="Top">
                <StackPanel>
                    <StackPanel.Style>
                        <Style TargetType="StackPanel">
                            <Setter Property="Visibility" Value="Collapsed" />
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding Type}"
                                             Value="B">
                                    <Setter Property="Visibility" Value="Visible" />
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </StackPanel.Style>
                    <Label Content="{Binding QuestionText}" />
                    <ListView ItemsSource="{Binding Answers}">
                        <ListView.ItemTemplate>
                            <DataTemplate>
                                <CheckBox Content="{Binding}" />
                            </DataTemplate>
                        </ListView.ItemTemplate>
                    </ListView>
                </StackPanel>
            </StackPanel>
        </DataTemplate>
    </ListView.ItemTemplate>
