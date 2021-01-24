    <UserControl.Resources>
        <BooleanToVisibilityConverter x:Key="BooleanToVisibilityConverter" />
        <Style TargetType="ListViewItem">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="ListViewItem">
                        <StackPanel Orientation="Horizontal">
                            <Border x:Name="ItemBorder" Padding="2">
                                <StackPanel>
                                    <ContentPresenter />
                                </StackPanel>
                            </Border>
                            <Border Name="Separator" Width="2" Margin="5,10" HorizontalAlignment="Center" Background="Red" Visibility="{Binding IsFirst, Converter={StaticResource BooleanToVisibilityConverter}}" />
                        </StackPanel>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsSelected" Value="True">
                                <Setter TargetName="ItemBorder" Property="Border.Background" Value="Blue" />
                                <Setter TargetName="ItemBorder" Property="Border.BorderBrush" Value="Green" />
                            </Trigger>
                            <DataTrigger Binding="{Binding ElementName=ItemBorder, Path=IsMouseOver}" Value="True">
                                <Setter TargetName="ItemBorder" Property="Border.Background" Value="Yellow" />
                            </DataTrigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </UserControl.Resources>
    <StackPanel>
        <ListView Name="Items">
            <ListView.ItemsPanel>
                <ItemsPanelTemplate>
                    <StackPanel Orientation="Horizontal" />
                </ItemsPanelTemplate>
            </ListView.ItemsPanel>
        </ListView>
    </StackPanel>
