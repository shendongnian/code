    <Style TargetType="Navigation:HtNavigationMenuCategoryItem">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="Navigation:HtNavigationMenuCategoryItem">
                    <Grid Margin="10,10,10,0">
                        <StackPanel Orientation="Vertical">
                            <ItemsControl ItemsSource="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=CategoryItems}">
                                <ItemsControl.ItemContainerStyle>
                                    <Style TargetType="Navigation:HtNavigationMenuCategoryItem">
                                        <Setter Property="Template">
                                            <Setter.Value>
                                                <ControlTemplate TargetType="Navigation:HtNavigationMenuCategoryItem">
                                                    <Controls:FooControl Text="test" Foreground="Yellow"></TextBlock>
                                                </ControlTemplate>
                                            </Setter.Value>
                                        </Setter>
                                    </Style>
                                </ItemsControl.ItemContainerStyle>
                            </ItemsControl>
                        </StackPanel>
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
