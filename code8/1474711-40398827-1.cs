           <ListBox ItemsSource="{Binding}">
            <ListBox.Resources>
                <DataTemplate x:Key="template1">
                    <StackPanel Orientation="Horizontal">
                        <CheckBox IsChecked="{Binding Path=IsSelected}" />
                        <Rectangle Height="20"
                                   Width="20">
                            <Rectangle.Style>
                                <Style TargetType="Rectangle">
                                    <Setter Property="Fill"
                                            Value="Blue" />
                                    <Style.Triggers>
                                        <DataTrigger Binding="{Binding Path=IsSelected}"
                                                     Value="True">
                                            <Setter Property="Fill"
                                                    Value="Red" />
                                        </DataTrigger>
                                    </Style.Triggers>
                                </Style>
                            </Rectangle.Style>
                        </Rectangle>
                    </StackPanel>
                </DataTemplate>
            </ListBox.Resources>
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <ContentControl ContentTemplate="{StaticResource template1}" Content="{Binding}">
                   
                    </ContentControl>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
