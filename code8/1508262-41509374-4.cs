    <Style TargetType="{x:Type local:MyCustomControl}">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type local:MyCustomControl}">
                    <Border Background="{TemplateBinding Background}"
                            BorderBrush="{TemplateBinding BorderBrush}"
                            BorderThickness="{TemplateBinding BorderThickness}">
                        <ListView x:Name="PART_ListView"
                                  ItemsSource="{Binding Items,RelativeSource={RelativeSource TemplatedParent}}">
                            <ListView.View>
                                <GridView>
                                    <GridView.Columns>
                                        <GridViewColumn Header="DEF"/>
                                    </GridView.Columns>
                                </GridView>
                            </ListView.View>
                        </ListView>
                    </Border>
                    <ControlTemplate.Triggers>
                        <Trigger Property="HasCustomView" Value="True">
                            <Setter TargetName="PART_ListView" Property="View" Value="{Binding MyView,RelativeSource={RelativeSource TemplatedParent}}"/>
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
