    <local:ItemsVisibleConverter x:Key="ItemsVisibleConverter" />
    
    <Style x:Key="CustomPropertyItemGroupContainerStyle" TargetType="{x:Type GroupItem}">
        <Setter Property="Control.Template">
            <Setter.Value>
                <ControlTemplate>
                    <Border>
                        <Expander Style="{StaticResource ExpanderStyle}" Header="{Binding Name}" IsExpanded="True">
                            <ItemsPresenter />
                        </Expander>
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
                
        <Style.Triggers>
            <DataTrigger Binding="{Binding Path=Items, Converter={StaticResource ItemsVisibleConverter}}" Value="False">
                <Setter Property="Visibility" Value="Collapsed" />
            </DataTrigger>
        </Style.Triggers>
    </Style>
